using UnityEngine;

namespace ClassicGames.Singletons
{
    public class State
    {
        private static State _instance;

        public static State Instance => _instance ??= new();

        private int _bestScore;
        public int BestScore
        {
            get => _bestScore;
            set
            {
                if (value <= _bestScore) return;
                
                _bestScore = value;
                PlayerPrefs.SetInt(Constants.BEST_SCORE_IN_PHYSICS_BALL, value);
                PlayerPrefs.Save();
            }
        }

        private State()
        {
            LoadScore();
        }

        private void LoadScore()
        {
            BestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE_IN_PHYSICS_BALL);
        }
    }
}