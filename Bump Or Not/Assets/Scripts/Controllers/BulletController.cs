using Views;
using Models;

namespace Controllers
{
    public class BulletController
    {
        BulletModel bulletModel;
        public BulletController(BulletModel bulletModel)
        {
            this.bulletModel = bulletModel;

            BulletView.OnDamagableCollision += OnDamagableCollision;
        }

        private void OnDamagableCollision(BulletView bullet, IDamagable damagable)
        {
            damagable.TakeDamage(bulletModel.BulletDamage);
            bullet.Destroy();
        }
    }
}
