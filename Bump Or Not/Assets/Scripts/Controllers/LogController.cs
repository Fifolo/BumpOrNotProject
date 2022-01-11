using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class LogController
    {
        public LogController()
        {
            GameModel.OnGameOver += OnOnGameFinished;
            GameModel.OnGameStart += OnGameStart;
        }

        private void OnGameStart()
        {
            Debug.Log("Game starts");
        }

        private void OnOnGameFinished()
        {
            Debug.Log("Player collided with bigger obstacle, game finished");
        }
    }
}