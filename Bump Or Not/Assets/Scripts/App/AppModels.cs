using UnityEngine;
using Models;

public class AppModels : MonoBehaviour
{
    [SerializeField] PlayerModel playerModel;
    [SerializeField] EnemyModel enemyModel;
    [SerializeField] GameModel gameModel;
    [SerializeField] BulletModel bulletModel;
    [SerializeField] ObstacleModel obstacleModel;
    [SerializeField] SpawnerModel spawnerModel;
    [SerializeField] ScoreModel scoreModel;
    [SerializeField] CollectablesModel collectablesModel;
    [SerializeField] PoolerModel obstaclePooler;
    public PlayerModel PlayerModel => playerModel;
    public EnemyModel EnemyModel => enemyModel;
    public GameModel GameModel => gameModel;
    public BulletModel BulletModel => bulletModel;
    public ObstacleModel ObstacleModel => obstacleModel;
    public SpawnerModel ObstacleSpawnerModel => spawnerModel;
    public ScoreModel ScoreModel => scoreModel;
    public CollectablesModel CollectablesModel => collectablesModel;
    public PoolerModel ObstaclePoolerModel => obstaclePooler;
}
