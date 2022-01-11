using Views;
using Models;

namespace Controllers
{
    public class ObstacleController
    {
        ObstacleModel model;
        Pooler<ObstacleView> pooler;
        private float difficultyMultiplier = 1f;
        public ObstacleController(ObstacleModel model, Pooler<ObstacleView> pooler)
        {
            this.model = model;
            this.pooler = pooler;

            ObstacleView.OnObstacleStart += OnObstacleStart;
            ObstacleView.OnObstacleEnable += OnObstacleEnable;
            GameModel.OnDifficultyIncrease += OnDifficultyIncrease;
        }

        private void OnObstacleStart(ObstacleView obj) => obj.InitializePooler(pooler);

        private void OnDifficultyIncrease() => difficultyMultiplier *= model.DifficultyIncreaseMultiplier;

        private void OnObstacleEnable(ObstacleView obstacle)
        {
            obstacle.Initialize(model.BaseSpeed * difficultyMultiplier, model.BaseHealth * difficultyMultiplier);
            obstacle.SetGravity(model.UseGravity);
            obstacle.SetRandomRotation();
            obstacle.SetRandomColor();
            obstacle.SetRandomScale(model.MaxScale);
        }
    }
}
