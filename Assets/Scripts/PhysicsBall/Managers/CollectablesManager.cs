using System;
using System.Collections.Generic;
using ClassicGames.PhysicsBall.Triggers;
using ClassicGames.Singletons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

namespace ClassicGames.PhysicsBall.Managers
{
    public class CollectablesManager : MonoBehaviour, IGameStageListener
    {
        [SerializeField] private Rect spaceToGenerate;
        [SerializeField] private GameObject prefabCollectable;

        private readonly HashSet<GameObject> _collectables = new();

        private int _score = 0;
        public UnityEvent<int> changedScore = new();

        private void GenerateCollectable()
        {
            Vector2 offset = new Vector2(Random.Range(0, spaceToGenerate.width), Random.Range(0, spaceToGenerate.height));
            GameObject collectable = Instantiate(prefabCollectable, spaceToGenerate.position + offset, Quaternion.identity);
            _collectables.Add(collectable);
            collectable.GetComponent<TriggerEnteredEvent>().triggerEnteredEvent.AddListener(OnCollected);
        }

        private void OnCollected(GameObject trigger, GameObject visitor)
        {
            if (_collectables.Contains(trigger))
            {
                _collectables.Remove(trigger);
                Destroy(trigger);
                changedScore.Invoke(++_score);
                checkBestScore();
                GenerateCollectable();
            }
        }

        private void checkBestScore()
        {
            State.Instance.BestScore = _score;
        }

        /*
         * Place is used for generating news balls.
         */
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 1f, 0f, 0.3f);
            Gizmos.DrawCube(spaceToGenerate.center, spaceToGenerate.size);
        }

        void IGameStageListener.OnGameInitialized()
        {
            changedScore.Invoke(_score = 0);
        }

        void IGameStageListener.OnGameStarted()
        {
            GenerateCollectable();
        }

        void IGameStageListener.OnGameWasOver(int score)
        {
            foreach (var collectable in _collectables)
            {
                Destroy(collectable);
            }
            _collectables.Clear();
        }
    }
}