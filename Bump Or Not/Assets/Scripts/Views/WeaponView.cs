using Models;
using UnityEngine;

namespace Views
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] WeaponModel weaponModel;
        [SerializeField] Transform nozzle;

        float timeToFire;
        public bool CanFire(float time) => time >= timeToFire;

        public void Fire(Vector3 destination)
        {
            if (CanFire(Time.time))
            {
                timeToFire = Time.time + weaponModel.FireCooldown;
                ShootProjectile(destination);
            }
        }

        void ShootProjectile(Vector3 direction)
        {
            Vector3 nozzlePosition = nozzle.position;
            GameObject bullet = Instantiate(weaponModel.BulletModel.BulletPrefab, nozzlePosition, Quaternion.identity);

            if (bullet.TryGetComponent(out BulletView bulletView))
            {
                bulletView.InitializeBullet(weaponModel.ProjectileSpeed, direction);
            }
            else
            {
                Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                rigid.velocity = direction * weaponModel.ProjectileSpeed;
                rigid.useGravity = false;
            }
        }
    }
}