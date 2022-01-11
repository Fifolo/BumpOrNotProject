using Views;
using Models;

namespace Controllers
{
    public class ScoreController
    {
        ScoreModel scoreModel;
        public ScoreController(ScoreModel scoreModel)
        {
            this.scoreModel = scoreModel;

            GameModel.OnGameStart += OnGameStart;
            GameModel.OnGameOver += OnGameOver;

            ScoreIncreaserView.OnPlayerCollision += ScoreIncreaserCollision;
            PlayerView.OnPlayerCollision += OnPlayerCollision;
            ObstacleView.OnObstacleWithBulletDestroyed += OnObstacleDestroy;
        }

        private void ScoreIncreaserCollision(ScoreIncreaserView scoreIncreaser)
        {
            scoreModel.ScoreIncreaserPicked(scoreIncreaser.Amount);
            scoreIncreaser.Destroy();
        }

        private void OnGameStart() => scoreModel.NewGameStarted();
        private void OnGameOver() => scoreModel.GameFinish();
        private void OnPlayerCollision(PlayerView player, CollidableObject obj)
        {
            if (player.CollisionForce > obj.CollisionForce)
                scoreModel.ObstacleDestroyedWithCollision(player.CollisionForce, obj.CollisionForce);
        }
        private void OnObstacleDestroy() => scoreModel.ObstacleDestroyedWithBullet();

    }
}