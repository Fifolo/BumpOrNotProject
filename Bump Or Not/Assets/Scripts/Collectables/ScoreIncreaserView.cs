using UnityEngine;
using System;

namespace Views
{
    public class ScoreIncreaserView : PlayerCollectableView
    {
        public static event Action<ScoreIncreaserView> OnScoreInreaserAwake;
        public static event Action<ScoreIncreaserView> OnPlayerCollision;

        private float _amount = 10f;
        public float Amount => _amount;
        protected override void Awake()
        {
            base.Awake();
            OnScoreInreaserAwake?.Invoke(this);
        }

        public override void Interact(PlayerView player) => OnPlayerCollision?.Invoke(this);
        public void Initialize(float scoreAmount) => _amount = scoreAmount;
    }
}