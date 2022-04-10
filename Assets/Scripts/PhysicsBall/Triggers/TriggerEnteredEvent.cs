using UnityEngine;
using UnityEngine.Events;

namespace ClassicGames.PhysicsBall.Triggers
{
    public class TriggerEnteredEvent : MonoBehaviour
    {
        // trigger and visitor
        public UnityEvent<GameObject, GameObject> triggerEnteredEvent = new();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            triggerEnteredEvent.Invoke(gameObject, collision.gameObject);
        }
    }
}