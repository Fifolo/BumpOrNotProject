using Views;
using Models;

namespace Controllers
{
    public class SpawnerController
    {
        SpawnerView spawnerView;
        SpawnerModel spawnerModel;
        public SpawnerController(SpawnerModel spawnerModel, AppViews views)
        {
            this.spawnerView = views.ObstacleSpawnerView;
            this.spawnerModel = spawnerModel;

            GameModel.OnGameOver += OnGameFinished;
            GameModel.OnGameStart += OnGameStart;
            GameModel.OnDifficultyIncrease += OnDifficultyIncrease;

            spawnerView.Initialize(views.ObstaclePooler, views.CollectablesPooler
                , spawnerModel.SpawnRange, spawnerModel.MinSpawnRate, spawnerModel.MaxSpawnRate, spawnerModel.DifficultyIncreaseNumber);
        }

        private void OnDifficultyIncrease() => spawnerView.AdjustSpawnRate(spawnerModel.DifficultyIncreaseMultipler);

        private void OnGameStart() => spawnerView.StartSpawning();

        private void OnGameFinished() => spawnerView.StopSpawning();
    }
}
