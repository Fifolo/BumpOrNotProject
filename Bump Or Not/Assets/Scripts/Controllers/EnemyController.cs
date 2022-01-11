using Models;
using Views;

namespace Controllers
{
    public class EnemyController
    {
        EnemyModel enemyModel;
        public EnemyController(EnemyModel enemyModel)
        {
            this.enemyModel = enemyModel;

            EnemyView.OnEnemyEnable += OnEnemyEnable;
        }
        private void OnEnemyEnable(EnemyView enemy)
        {
            enemy.Initialize(enemyModel.MovementSpeed, enemyModel.MaxHealth);
        }
    }
}