using UnityEngine;
using System;

namespace Views
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMover))]
    public class BulletView : MonoBehaviour
    {
        public static event Action<BulletView, IDamagable> OnDamagableCollision;
        [SerializeField] float lifeSpan = 4f;

        private IMover _mover;

        private void Awake()
        {
            _mover = GetComponent<IMover>();
            _mover.Initialize(Vector3.right, 5);
            GetComponent<Rigidbody>().useGravity = false;
        }
        void Start() => Destroy(gameObject, lifeSpan);
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IDamagable damagable))
            {
                OnDamagableCollision?.Invoke(this, damagable);
            }
        }
        public void InitializeBullet(float movementSpeed, Vector3 direction) => _mover.Initialize(direction, movementSpeed);
        public void Destroy() => Destroy(gameObject);
    }
}