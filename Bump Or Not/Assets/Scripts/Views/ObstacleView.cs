using UnityEngine;
using System;

namespace Views
{
    [RequireComponent(typeof(IMover))]
    public class ObstacleView : CollidableObject, IDamagable, IPoolable
    {
        public static event Action<ObstacleView> OnObstacleStart;
        public static event Action<ObstacleView> OnObstacleEnable;
        public static event Action OnObstacleWithBulletDestroyed;

        private float _currentHealth = 10f;
        private float _movementSpeed = 3f;

        private Pooler<ObstacleView> _pooler;
        private Transform _obstacleTransform;
        private IMover _mover;
        private MeshRenderer _obstacleRenderer;

        protected override void Awake()
        {
            base.Awake();
            _obstacleRenderer = GetComponentInChildren<MeshRenderer>();
            _mover = GetComponent<RigidbodyMover>();
            _obstacleTransform = transform;
        }
        private void Start() => OnObstacleStart?.Invoke(this);
        private void OnEnable()
        {
            OnObstacleEnable?.Invoke(this);
            _mover.Initialize(Vector3.left, _movementSpeed);
        }

        public void SetRandomRotation()
        {
            Vector3 rotationVector = new Vector3(
                UnityEngine.Random.Range(0f, 10f),
                UnityEngine.Random.Range(0f, 10f),
                UnityEngine.Random.Range(0f, 10f));

            _rb.AddTorque(rotationVector, ForceMode.Impulse);
        }

        public void SetGravity(bool shouldUseGravity) => _rb.useGravity = shouldUseGravity;
        public void InitializePooler(Pooler<ObstacleView> pooler)
        {
            if (pooler)
                _pooler = pooler;
        }
        public void Initialize(float maxMoveSpeed, float maxHealth)
        {
            if (maxMoveSpeed > 0)
                _movementSpeed = UnityEngine.Random.Range(_movementSpeed, maxMoveSpeed);

            if (maxHealth > 0)
                _currentHealth = maxHealth;
        }
        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0)
            {
                Destroy();
                OnObstacleWithBulletDestroyed?.Invoke();
            }
        }
        public void SetRandomColor()
        {
            Color randomColor = new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f)
                );

            _obstacleRenderer.material.color = randomColor;
        }
        public void SetRandomScale(float maxScale)
        {
            float randomScale = UnityEngine.Random.Range(0.5f, maxScale);
            Vector3 newScale = new Vector3(randomScale, randomScale, randomScale);

            if (HasBoxCollider)
            {
                newScale.x = UnityEngine.Random.Range(0.5f, maxScale);
                newScale.y = UnityEngine.Random.Range(0.5f, maxScale);
                newScale.z = UnityEngine.Random.Range(0.5f, maxScale);
            }

            _obstacleTransform.localScale = newScale;
            SetCollisionForce();
        }

        public override void Destroy()
        {
            if (_pooler)
                ReturnToPool();

            else Destroy(gameObject);
        }

        public void ReturnToPool()
        {
            if (_pooler)
                _pooler.ReturnObject(this);
        }
    }
}
