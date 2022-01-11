using Models;
using Views;

namespace Controllers
{
    public class PlayerController
    {
        PlayerModel playerModel;
        PlayerView playerView;
        public PlayerController(PlayerView playerView, PlayerModel playerModel)
        {
            this.playerModel = playerModel;
            this.playerView = playerView;

            playerView.Initialize(playerModel.BaseMoveSpeed);

            GameModel.OnGameOver += OnOnGameFinished;
            GameModel.OnGameStart += OnGameStart;
            GameModel.OnGamePaused += OnGamePaused;
            GameModel.OnGameUnPaused += OnGameUnPaused;

            PlayerView.OnPlayerSpacePressed += OnPlayerSpacePressed;
            PlayerView.OnPlayerGrowPressed += OnPlayerGrowPressed;
            PlayerView.OnPlayerShrinkPressed += OnPlayerShrinkPressed;
            PlayerView.OnPlayerUpBeingHeld += OnPlayerLeftBeingHeld;
            PlayerView.OnPlayerDownBeingHeld += OnPlayerRightBeingHeld;

            PlayerView.OnPlayerCollision += OnPlayerCollision;
        }

        private void OnGameStart() => playerView.ListenForInput = true;
        private void OnGamePaused() => playerView.ListenForInput = false;
        private void OnGameUnPaused() => playerView.ListenForInput = true;
        private void OnOnGameFinished()
        {
            playerView.ListenForInput = false;
            playerView.Destroy();
        }

        private void OnPlayerCollision(PlayerView player, CollidableObject obj)
        {
            if (obj.CollisionForce < player.CollisionForce)
                obj.Destroy();
        }

        private void OnPlayerRightBeingHeld(float zPosition, out float movementInput)
        {
            if (zPosition > -playerModel.ZBound)
                movementInput = -1f;

            else movementInput = 0;
        }

        private void OnPlayerLeftBeingHeld(float zPosition, out float movementInput)
        {
            if (zPosition < playerModel.ZBound)
                movementInput = 1f;

            else movementInput = 0;
        }

        private void OnPlayerShrinkPressed(PlayerView playerView, float currentScale)
        {
            if (playerModel.CanShrink(currentScale))
            {
                playerView.Shrink(1 - playerModel.GrowMultiplier);
                playerView.AdjustMovementSpeed(1 + playerModel.GrowMultiplier);
            }
        }

        private void OnPlayerGrowPressed(PlayerView playerView, float currentScale)
        {
            if (playerModel.CanGrow(currentScale))
            {
                playerView.Grow(1 + playerModel.GrowMultiplier);
                playerView.AdjustMovementSpeed(1 - playerModel.GrowMultiplier);
            }
        }

        private void OnPlayerSpacePressed(PlayerView playerView, bool hasSomethingBeneath)
        {
            if (hasSomethingBeneath)
                playerView.Jump(playerModel.JumpForce);
        }

    }
}