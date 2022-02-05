using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace ClassicGames.PhysicsBall.Triggers
{
    public class CollectablesManager : MonoBehaviour
    {
        [SerializeField] private Rect _spaceForGeneration;
        [SerializeField] private GameObject _prefabCollectable;

        private HashSet<GameObject> _collectables = new HashSet<GameObject>();

        public UnityEvent<int> OnChangeScore;

        public int Score { private set; get; }

        void Start()
        {
            Score = 0;
            GenerateCollectable();
        }

        public void Restart()
        {
            foreach (var collectable in _collectables)
            {
                Destroy(collectable);
            }
            _collectables.Clear();
            GenerateCollectable();
            OnChangeScore.Invoke(Score = 0);
        }

        private void GenerateCollectable()
        {
            Vector2 offset = new Vector2(Random.Range(0, _spaceForGeneration.width), Random.Range(0, _spaceForGeneration.height));
            GameObject collectable = Instantiate(_prefabCollectable, _spaceForGeneration.position + offset, Quaternion.identity);
            collectable.GetComponent<TriggerToCollectables>().OnCollected = ReactOnCollected;
            _collectables.Add(collectable);
        }

        private void ReactOnCollected(GameObject collectable)
        {
            if (_collectables.Contains(collectable))
            {
                Score++;
                OnChangeScore.Invoke(Score);
                _collectables.Remove(collectable);
                GenerateCollectable();
            }
        }

        /*
         * Place is used for generating news balls.
         */
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 1f, 0f, 0.3f);
            Gizmos.DrawCube(_spaceForGeneration.center, _spaceForGeneration.size);
        }
    }
}
