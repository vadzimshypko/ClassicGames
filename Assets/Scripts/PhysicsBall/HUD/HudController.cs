using UnityEngine;

namespace ClassicGames.PhysicsBall.HUD
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI ballsCounter;
        [SerializeField] private TMPro.TextMeshProUGUI scoreCounter;

        public void OnChangedScore(int score)
{
            scoreCounter.text = score.ToString();
        }

        public void OnChangedNumberOfBalls(int count)
        {
            ballsCounter.text = count.ToString();
        }
    }
}
