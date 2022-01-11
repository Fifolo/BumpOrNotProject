using UnityEngine;
using System;

namespace Views
{
    public class SpeedBoostView : PlayerCollectableView
    {
        public static event Action<SpeedBoostView> OnSpeedBoostAwake;

        private float _multiplier = 1.5f;
        private float _duration = 2f;
        protected override void Awake()
        {
            base.Awake();
            OnSpeedBoostAwake?.Invoke(this);
        }
        public override void Interact(PlayerView player)
        {
            player.IncreaseMovementSpeed(_duration, _multiplier);
        }
        public void Initialize(float duration, float multiplier)
        {
            _duration = duration;
            _multiplier = multiplier;
        }

    }
}
