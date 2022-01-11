using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/WeaponModel")]
    public class WeaponModel : ScriptableObject
    {
        [Min(0.1f)]
        [SerializeField] float fireCooldown = 1f;
        [SerializeField] float projectileSpeed = 10f;
        [SerializeField] BulletModel bulletModel;

        public float FireCooldown => fireCooldown;
        public float ProjectileSpeed => projectileSpeed;
        public BulletModel BulletModel => bulletModel;
    }
}