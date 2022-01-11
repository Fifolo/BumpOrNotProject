using UnityEngine;
using System;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/ScoreModel")]
    public class ScoreModel : ScriptableObject
    {
        public static event Action<float> OnCurrentScoreChanged;
        [Min(1)]
        [SerializeField] int bulletPointsForObstacle = 10;
        [Min(1)]
        [SerializeField] int collisionPointsForObstacle = 10;

        private float highScore = 0;
        private int obstaclesDestroyed = 0;
        private float currentScore = 0;

        public float GameScore => currentScore;
        public int ObstaclesDestroyed => obstaclesDestroyed;

        public void GameFinish()
        {
            if (currentScore > highScore)
                highScore = currentScore;
        }
        public void NewGameStarted() => ResetScores();

        private void ResetScores()
        {
            currentScore = 0;
            obstaclesDestroyed = 0;
        }

        public void ObstacleDestroyedWithBullet()
        {
            obstaclesDestroyed++;
            UpdateCurrentScore(bulletPointsForObstacle);
        }

        private void UpdateCurrentScore(float amount)
        {
            currentScore += amount;
            OnCurrentScoreChanged?.Invoke(currentScore);
        }
        public void ScoreIncreaserPicked(float increaserPoints) => UpdateCurrentScore(increaserPoints);

        public void ObstacleDestroyedWithCollision(float playerForce, float obstacleForce)
        {
            if (obstacleForce <= 0) return;

            float multiplier = 1;
            float sizeDifference = playerForce - obstacleForce;
            if (sizeDifference < 1) multiplier = 2f;
            else if (sizeDifference >= 1 && sizeDifference < 3) multiplier = 1.5f;

            obstaclesDestroyed++;
            UpdateCurrentScore(collisionPointsForObstacle * multiplier);
        }
    }
}
