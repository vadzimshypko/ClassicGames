using UnityEngine;

namespace ClassicGames.Utils
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpeedLimiter : MonoBehaviour
    {
        public float speed;
        private void FixedUpdate()
        {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            if (speed < body.velocity.magnitude)
            {
                body.velocity = body.velocity.normalized * speed;
            }
        }
    }
}
