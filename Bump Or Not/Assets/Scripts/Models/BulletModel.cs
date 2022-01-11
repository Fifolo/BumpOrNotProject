using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/BulletModel")]
    public class BulletModel : ScriptableObject
    {
        [SerializeField] float bulletDamage = 5f;
        [SerializeField] GameObject bulletPrefab;
        public float BulletDamage => bulletDamage;
        public GameObject BulletPrefab => bulletPrefab;
    }
}
