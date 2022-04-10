using System.Collections.Generic;
using ClassicGames.Singletons;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ClassicGames.PhysicsBall
{
    [DisallowMultipleComponent]
    public class GameStageSystem : MonoBehaviour
    {
        private BoardInput _controls;

        private int _balls;

        private readonly List<IGameStageListener> _gameStateListeners = new();

        public void InitNewGame()
        {
            for (int i = 0; i < _gameStateListeners.Count; i++)
            {
                _gameStateListeners[i].OnGameInitialized();
            }
        }

        public void OnChangedNumberOfBalls(int count)
        {
            _balls = count;
            if (_balls == 0)
            {
                FinishGames();
            }
        }

        private void Awake()
        {
            Time.timeScale = 0;
            _controls = new BoardInput();
            _controls.Player.Move.performed += TryStartGame;
            RefillGameStateListeners();
            InitNewGame();
        }

        private void RefillGameStateListeners()
        {
            _gameStateListeners.Clear();
            foreach (var component in FindObjectsOfType<Component>())
            {
                if (component is IGameStageListener listener)
                {
                    _gameStateListeners.Add(listener);
                }
            }
            Debug.Log($"Refilled list of game stage listeners. New count: {_gameStateListeners.Count.ToString()}");
        }


        private void OnEnable()
        {
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        private void TryStartGame(CallbackContext context)
        {
            if (Time.timeScale == 0 && !Mathf.Approximately(context.ReadValue<float>(), 0) && _balls > 0)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            foreach (var listener in _gameStateListeners)
            {
                listener.OnGameStarted();
            }
        }

        private void FinishGames()
        {
            Time.timeScale = 0;
            for (int i = 0; i < _gameStateListeners.Count; i++)
            {
                IGameStageListener listener = _gameStateListeners[i];
                listener.OnGameWasOver(State.Instance.Score);
            }
        }
    }
}