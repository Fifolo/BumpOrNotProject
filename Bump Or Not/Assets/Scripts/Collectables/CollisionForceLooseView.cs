using System;

namespace Views
{
    public class CollisionForceLooseView : PlayerCollectableView
    {
        public static event Action<CollisionForceLooseView> OnForceLooseAwake;

        private float _forceMultiplier = 3f;
        private float _duration = 1f;
        protected override void Awake()
        {
            base.Awake();
            OnForceLooseAwake?.Invoke(this);
        }

        public void Initialize(float multiplier, float duration)
        {
            _forceMultiplier = multiplier;
            _duration = duration;
        }
        public override void Interact(PlayerView player)
        {
            player.ChangeCollisionForce(_forceMultiplier, _duration);
        }
    }
}