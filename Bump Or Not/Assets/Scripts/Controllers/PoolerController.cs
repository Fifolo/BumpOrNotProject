using Views;
using Models;

public class PoolerController
{
    PoolerModel poolerModel;

    public PoolerController(PoolerModel poolerModel)
    {
        this.poolerModel = poolerModel;

        Pooler<ObstacleView>.OnPoolerStart += OnObstacleStart;
        Pooler<PlayerCollectableView>.OnPoolerStart += OnCollectableStart;
    }

    private void OnCollectableStart(Pooler<PlayerCollectableView> pooler)
    {
        pooler.Initialze(poolerModel.CollectablesPrefabs, poolerModel.AmountPerCollectable);
    }

    private void OnObstacleStart(Pooler<ObstacleView> pooler)
    {
        pooler.Initialze(poolerModel.ObstaclePrefabs, poolerModel.AmountPerObstacle);
    }
}
