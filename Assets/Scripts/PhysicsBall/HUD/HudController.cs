using UnityEngine;

namespace ClassicGames.PhysicsBall.HUD
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _ballsCounter;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreCounter;

        public void ChangeBallsCounter(int count)
        {
            _ballsCounter.text = count.ToString();
        }

        public void ChangeScoreCounter(int score)
        {
            _scoreCounter.text = score.ToString();
        }
    }
}
