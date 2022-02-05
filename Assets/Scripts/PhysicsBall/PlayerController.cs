using UnityEngine;

namespace ClassicGames.PhysicsBall
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _directionVector = new Vector2();
        private Rigidbody2D _rigidbody2D;

        public float speed;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float direction = Input.GetAxisRaw("Horizontal");
            _directionVector.Set(direction * speed * Time.fixedDeltaTime, 0);
            _rigidbody2D.MovePosition(_rigidbody2D.position + _directionVector);
        }
    }
}
