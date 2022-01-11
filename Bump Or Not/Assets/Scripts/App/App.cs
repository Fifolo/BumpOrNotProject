using Controllers;
using UnityEngine;

public class App : MonoBehaviour
{
    PlayerController playerController;
    EnemyController enemyController;
    LogController logController;
    WeaponController weaponController;
    GameController gameController;
    BulletController bulletController;
    ObstacleController obstacleController;
    SpawnerController obstacleSpawnerController;
    UIController uIController;
    ScoreController scoreController;
    CollectablesController collectablesController;
    PoolerController poolerController;

    [SerializeField] private AppViews appViews;
    [SerializeField] private AppModels appModels;
    public AppViews Views => appViews;
    public AppModels Models => appModels;

    private void Awake()
    {
        poolerController = new PoolerController(Models.ObstaclePoolerModel);
        obstacleSpawnerController = new SpawnerController(Models.ObstacleSpawnerModel, appViews);
        playerController = new PlayerController(Views.PlayerView, Models.PlayerModel);
        weaponController = new WeaponController(this);
        bulletController = new BulletController(Models.BulletModel);
        logController = new LogController();
        obstacleController = new ObstacleController(Models.ObstacleModel, Views.ObstaclePooler);
        enemyController = new EnemyController(Models.EnemyModel);
        scoreController = new ScoreController(Models.ScoreModel);
        collectablesController = new CollectablesController(Models.CollectablesModel, Views.CollectablesPooler);
        uIController = new UIController(Views.UIView, Models.ScoreModel);

        gameController = new GameController(Models.GameModel);
    }
}