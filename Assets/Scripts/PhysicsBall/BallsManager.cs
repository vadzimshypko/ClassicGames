using ClassicGames.PhysicsBall.Triggers;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace ClassicGames.PhysicsBall
{
    public class BallsManager : MonoBehaviour
    {
        [SerializeField] private DeathLineCollisionWithBall _deathLine;
        [SerializeField] private GameObject _prefabBall;
        [SerializeField] private Rect _spaceForGeneration;

        private LinkedList<GameObject> _balls = new LinkedList<GameObject>();

        public UnityEvent<int> OnChangedBallsCount;

        public void Start()
        {
            _deathLine.DeathLineCollision += (collider) => { RemoveBall(collider.gameObject); };
        }

        /* External methods */

        public void RemoveLastBall()
        {
            if (_balls.Count != 0)
            {
                RemoveBall();
            }
        }

        public void GenerateNewBall()
        {
            GameObject newBall = Instantiate(_prefabBall, GetRandomPosition(), Quaternion.identity);
            SpriteRenderer newSprite = newBall.GetComponent<SpriteRenderer>();
            newSprite.color = GetRandomColor();
            _balls.AddLast(newBall);
            OnChangedBallsCount.Invoke(_balls.Count);

            Debug.Log("Generates ball with position = " + newBall.transform.position + ", color = " + newSprite.color);
        }

        /* Private methods */

        private void RemoveBall(GameObject ball = null)
        {
            if (ball != null)
            {
                _balls.Remove(ball);
            }
            else
            {
                ball = _balls.Last.Value;
                _balls.RemoveLast();
            }
            Destroy(ball);
            OnChangedBallsCount.Invoke(_balls.Count);
        }

        private Vector2 GetRandomPosition()
        {
            Vector2 offset = new Vector2(Random.Range(0, _spaceForGeneration.width), Random.Range(0, _spaceForGeneration.height));
            return _spaceForGeneration.position + offset;
        }

        private Color GetRandomColor()
        {
            return new Color(0.5F, 1f, Random.value, 1f);
        }

        /*
         * Place is used for generating news balls.
         */
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 1f, 0f, 0.3f);
            Gizmos.DrawCube(_spaceForGeneration.center, _spaceForGeneration.size);
        }
    }
}
