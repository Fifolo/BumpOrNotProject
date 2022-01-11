using UnityEngine;
using Views;

public class AppViews : MonoBehaviour
{
    [SerializeField] PlayerView playerView;
    [SerializeField] GameView gameView;
    [SerializeField] WeaponView weaponView;
    [SerializeField] SpawnerView spawnerView;
    [SerializeField] UIView uIView;
    [SerializeField] ScoreView scoreView;
    [SerializeField] Pooler<ObstacleView> obstaclePooler;
    [SerializeField] Pooler<PlayerCollectableView> collectablesPooler;

    public GameView GameView => gameView;
    public PlayerView PlayerView => playerView;
    public WeaponView WeaponView => weaponView;
    public SpawnerView ObstacleSpawnerView => spawnerView;
    public UIView UIView => uIView;
    public ScoreView ScoreView => scoreView;
    public Pooler<ObstacleView> ObstaclePooler => obstaclePooler;
    public Pooler<PlayerCollectableView> CollectablesPooler => collectablesPooler;

}