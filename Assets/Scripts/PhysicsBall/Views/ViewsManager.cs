using ClassicGames.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicGames.PhysicsBall.Views
{
    public class ViewsManager : MonoBehaviour, IGameStageListener
    {
        [SerializeField] private GameObject gameOverView;
        [SerializeField] private GameObject startGamesView;

        [SerializeField] private TMPro.TextMeshProUGUI scoreCounter;
        [SerializeField] private TMPro.TextMeshProUGUI bestScoreCounter;

        public void ReturnToMainMenu()
        {
            Debug.Log("Button: closes PhysicsBall and open MainMenu");
            SceneManager.LoadScene("MainMenu");
        }

        void IGameStageListener.OnGameInitialized()
        {
            gameOverView.SetActive(false);
            startGamesView.SetActive(true);
        }

        void IGameStageListener.OnGameStarted()
        {
            startGamesView.SetActive(false);
            gameOverView.SetActive(false);
        }

        void IGameStageListener.OnGameWasOver(int score)
        {
            scoreCounter.text = score.ToString();
            bestScoreCounter.text = State.Instance.BestScore.ToString();
            gameOverView.SetActive(true);
            startGamesView.SetActive(false);
        }
    }
}
