using Views;
using Models;

namespace Controllers
{
    public class GameController
    {
        GameModel gameModel;
        public GameController(GameModel gameModel)
        {
            this.gameModel = gameModel;
            gameModel.SetGameState(GameModel.GameState.MainMenu);

            PlayerView.OnPlayerCollision += OnPlayerCollision;
            GameView.OnGameViewStartGame += OnGameViewStart;
            GameView.OnPauseToggle += OnPauseToggle;
            SpawnerView.OnDifficultyAmountSpawned += OnDifficultyAmountSpawned;
        }

        private void OnDifficultyAmountSpawned(SpawnerView obj) => gameModel.IncreaseDifficulty();

        private void OnPauseToggle() => gameModel.PauseToggle();

        private void OnGameViewStart() => gameModel.StartGame();

        private void OnPlayerCollision(PlayerView player, CollidableObject obj)
        {
            if (obj.CollisionForce >= player.CollisionForce)
                gameModel.PlayerCollision();
        }
    }
}