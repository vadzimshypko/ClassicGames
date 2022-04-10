using UnityEngine;

namespace ClassicGames.PhysicsBall
{
    public class PlayerController : MonoBehaviour
    {
        private BoardInput _controls;

        private Vector2 _directionVector;
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float speed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _controls = new();
            _controls.Player.Move.started += move =>
            {
                Debug.Log(move.ReadValue<float>().ToString());
                _directionVector.Set(move.ReadValue<float>() * speed * Time.fixedDeltaTime, 0);
            };
            _controls.Player.Move.canceled+= move =>
            {
                _directionVector = Vector2.zero;
            };
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
        }
        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _directionVector;
        }
    }
}
