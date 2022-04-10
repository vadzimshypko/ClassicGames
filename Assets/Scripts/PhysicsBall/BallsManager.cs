using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClassicGames.PhysicsBall
{
    public class BallsManager : MonoBehaviour
    {
        private readonly LinkedList<GameObject> _balls = new();

        [SerializeField] private GameObject prefabBall;
        [SerializeField] private Rect spaceToGenerate;

        public UnityEvent<int> changedNumberOfBalls;

        /* Interface */

        public void GenerateNewBall()
        {
            var newBall = Instantiate(prefabBall, GenerateRandomPosition(spaceToGenerate), Quaternion.identity);
            var newSprite = newBall.GetComponent<SpriteRenderer>();
            newSprite.color = GenerateRandomColor();
            _balls.AddLast(newBall);
            changedNumberOfBalls.Invoke(_balls.Count);
            Debug.Log($"Generates ball with position = {newBall.transform.position.ToString()}, color = {newSprite.color.ToString()}");
        }

        public void OnDeathLineEntered(GameObject trigger, GameObject visitor)
        {
            RemoveBall(visitor);
        }

        /* Private methods */
        
        public void RemoveBall(GameObject ball = null)
        {
            if (_balls.Count <= 0)
            {
                Debug.LogError($"We try to remove ball: {ball}, but _balls.count = 0");
                Destroy(ball);
                return;
            }
            
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
            changedNumberOfBalls.Invoke(_balls.Count);
        }

        private Vector2 GenerateRandomPosition(Rect space)
        {
            Vector2 offset = new(Random.Range(0, space.width), Random.Range(0, space.height));
            return space.position + offset;
        }

        private Color GenerateRandomColor()
        {
            return new Color(0.5F, 1f, Random.value, 1f);
        }

        /*
         * Place is used for generating news balls.
         */
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 1f, 0f, 0.3f);
            Gizmos.DrawCube(spaceToGenerate.center, spaceToGenerate.size);
        }
    }
}