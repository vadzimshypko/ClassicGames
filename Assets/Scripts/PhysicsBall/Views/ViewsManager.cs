using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicGames.PhysicsBall.Views
{
    public class ViewsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _endGamesView;
        [SerializeField] private GameObject _startGamesView;

        [SerializeField] private TMPro.TextMeshProUGUI _scoreCounter;
        [SerializeField] private TMPro.TextMeshProUGUI _bestScoreCounter;

        [SerializeField] private GameStageController _gameStageController;

        void Start()
        {
            _startGamesView.SetActive(true);
            _endGamesView.SetActive(false);
        }

        public void StartGame()
        {
            _startGamesView.SetActive(false);
            _endGamesView.SetActive(false);
        }

        public void FinishGame(int score)
        {
            _scoreCounter.text = score.ToString();
            _bestScoreCounter.text = _gameStageController.BestScore.ToString();
            _endGamesView.SetActive(true);
            _startGamesView.SetActive(false);
        }

        public void RestartGame()
        {
            _endGamesView.SetActive(false);
            _startGamesView.SetActive(true);
        }

        public void ReturnToMainMenu()
        {
            Debug.Log("Button: closes PhysicsBall and open MainMenu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
