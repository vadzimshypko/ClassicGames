using System;

using UnityEngine;

namespace ClassicGames.PhysicsBall.Triggers
{
    public class DeathLineCollisionWithBall : MonoBehaviour
    {
        public event Action<Collider2D> DeathLineCollision;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DeathLineCollision?.Invoke(collision);
        }
    }
}