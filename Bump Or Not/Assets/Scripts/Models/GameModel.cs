using System;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/GameModel")]
    public class GameModel : ScriptableObject
    {
        public static event Action OnGameOver;
        public static event Action OnGameStart;
        public static event Action OnGamePaused;
        public static event Action OnGameUnPaused;
        public static event Action OnDifficultyIncrease;

        private GameState CurrentState = GameState.MainMenu;
        public enum GameState
        {
            MainMenu,
            Playing,
            Paused,
            GameOver
        }
        public void SetGameState(GameState newState) => CurrentState = newState;
        public void StartGame()
        {
            if (CurrentState == GameState.Playing) return;

            CurrentState = GameState.Playing;
            OnGameStart?.Invoke();
        }
        public void PlayerCollision()
        {
            if (CurrentState != GameState.Playing) return;

            CurrentState = GameState.GameOver;
            OnGameOver?.Invoke();
        }
        public void IncreaseDifficulty() => OnDifficultyIncrease?.Invoke();
        public void PauseToggle()
        {
            if (CurrentState != GameState.Playing || CurrentState != GameState.Paused) return;

            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                CurrentState = GameState.Paused;
                OnGamePaused?.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                CurrentState = GameState.Playing;
                OnGameUnPaused?.Invoke();
            }
        }
    }
}