using UnityEngine;
using System;

namespace Views
{
    [RequireComponent(typeof(IMover))]
    public class EnemyView : CollidableObject, IEnemyView, IDamagable
    {
        public static event Action<EnemyView> OnEnemyEnable;
        public static event Action<EnemyView> OnEnemyDisable;

        private float _currentHealth = 0;
        private float _movementSpeed = 5f;
        private IMover _mover;
        protected override void Awake()
        {
            base.Awake();
            _mover = GetComponent<IMover>();
            _mover.Initialize(Vector3.left, 5f);
        }
        private void OnEnable() => OnEnemyEnable?.Invoke(this);
        private void OnDisable() => OnEnemyDisable?.Invoke(this);

        public void Initialize(float movementSpeed, float maxHealth)
        {
            if (movementSpeed > 0)
                _movementSpeed = movementSpeed;
            if (maxHealth > 0)
                _currentHealth = maxHealth;

            _mover.Initialize(Vector3.left, _movementSpeed);
        }
        public void Die()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0)
                Die();
        }

        public override void Destroy() => Die();
    }
}