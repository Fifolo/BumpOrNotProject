using Views;
using Models;

namespace Controllers
{
    public class CollectablesController
    {
        CollectablesModel model;
        Pooler<PlayerCollectableView> pooler;
        public CollectablesController(CollectablesModel collectablesModel, Pooler<PlayerCollectableView> pooler)
        {
            model = collectablesModel;
            this.pooler = pooler;

            PlayerCollectableView.OnCollectableStart += OnCollectableStart;
            PlayerView.OnCollectableCollision += OnCollectableCollision;

            ScoreIncreaserView.OnScoreInreaserAwake += OnScoreInreaserAwake;
            SpeedBoostView.OnSpeedBoostAwake += OnMoveSpeedAwake;
            CollisionForceLooseView.OnForceLooseAwake += OnForceLooseAwake;
        }

        private void OnCollectableStart(PlayerCollectableView collectable) => collectable.InitializePool(pooler);

        private void OnForceLooseAwake(CollisionForceLooseView collectable)
        {
            collectable.Initialize(model.CollisionMultiplier, model.CollisionChangeTime);
        }

        private void OnCollectableCollision(PlayerView player, IPlayerCollectable collectable)
        {
            collectable.Interact(player);
        }

        private void OnMoveSpeedAwake(SpeedBoostView collectable)
        {
            collectable.Initialize(model.MoveSpeedTime, model.MoveSpeedMultiplier);
        }

        private void OnScoreInreaserAwake(ScoreIncreaserView increaser)
        {
            increaser.Initialize(model.ScoreInrease);
        }
    }
}