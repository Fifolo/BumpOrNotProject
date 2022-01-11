using UnityEngine;
using System.Collections.Generic;
using Views;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/PoolerModel")]
    public class PoolerModel : ScriptableObject
    {
        [Header("Obstacles")]
        [SerializeField] List<ObstacleView> obstaclePrefabs;
        [SerializeField] int amountPerObstacle = 10;

        [Header("Collectables")]
        [SerializeField] List<PlayerCollectableView> collectablesPrefabs;
        [SerializeField] int amountPerCollectable = 5;

        public List<ObstacleView> ObstaclePrefabs => obstaclePrefabs;
        public int AmountPerObstacle => amountPerObstacle;

        public List<PlayerCollectableView> CollectablesPrefabs => collectablesPrefabs;
        public int AmountPerCollectable => amountPerCollectable;

    }
}