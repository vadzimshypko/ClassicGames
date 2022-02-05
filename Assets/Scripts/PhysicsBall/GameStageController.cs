using ClassicGames.PhysicsBall.Triggers;

using UnityEngine;
using UnityEngine.Events;

namespace ClassicGames.PhysicsBall
{
    public class GameStageController : MonoBehaviour
    {

        public UnityEvent OnInitNewGame = new UnityEvent();
        public UnityEvent OnStartGame = new UnityEvent();
        public UnityEvent<int> OnGameOver = new UnityEvent<int>();

        [SerializeField] private BallsManager _ballsManager;
        [SerializeField] private CollectablesManager _collectablesManager;

        public int Score { get; set; }
        public int BestScore { get; private set; }
        public int Balls { get; private set; }

        private void Awake()
        {
            BestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE_IN_PHYSICS_BALL);
        }

        void Start()
        {
            Time.timeScale = 0;
        }

        //Start game when player start moving.
        void Update()
        {
            if (Time.timeScale == 0 && Input.GetAxisRaw("Horizontal") != 0 && Balls > 0)
            {
                StartGame();
            }
        }

        public void ListenChangingBallsCount(int count)
        {
            Balls = count;
            if (count == 0)
            {
                FinishGames();
            }
        }

        public void InitNewGame()
        {
            OnInitNewGame.Invoke();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            OnStartGame.Invoke();
        }

        private void FinishGames()
        {
            Time.timeScale = 0;
            OnGameOver.Invoke(Score);
            SaveResult();
            Debug.Log("Game over");
        }

        private void SaveResult()
        {
            if (BestScore < Score)
            {
                PlayerPrefs.SetInt(Constants.BEST_SCORE_IN_PHYSICS_BALL, Score);
                PlayerPrefs.Save(); 
                BestScore = Score;
            }
        }
    }
}
