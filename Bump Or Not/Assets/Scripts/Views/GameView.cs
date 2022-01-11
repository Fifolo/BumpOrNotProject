using UnityEngine;
using System;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        public static event Action OnGameViewStartGame;
        public static event Action OnPauseToggle;

        public void StartGame()
        {
            OnGameViewStartGame?.Invoke();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseToggle?.Invoke();
            }
        }
        public void PauseToggle() => OnPauseToggle?.Invoke();
    }
}