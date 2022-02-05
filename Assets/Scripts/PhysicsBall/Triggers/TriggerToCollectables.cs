using UnityEngine;

namespace ClassicGames.PhysicsBall.Triggers
{
    public class TriggerToCollectables : MonoBehaviour
    {
        public System.Action<GameObject> OnCollected;               

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollected?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}
