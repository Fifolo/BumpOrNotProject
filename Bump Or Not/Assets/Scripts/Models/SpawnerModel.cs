using UnityEngine;
using System.Collections.Generic;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/SpawnerModel")]
    public class SpawnerModel : ScriptableObject
    {
        [Range(0f, 3f)]
        [SerializeField] float spawnRange = 2f;
        [Min(0.1f)]
        [SerializeField] float minSpawnRate = 0.1f;
        [Min(2f)]
        [SerializeField] float maxSpawnRate = 3f;
        [Min(1)][Tooltip("After this number of objects have been spawned, decrease spawn rate")]
        [SerializeField] int difficultyIncreaseNumber = 10;
        [Range(0.99f, 0.5f)]
        [SerializeField] float difficultyIncreaseMultipler = 0.5f;

        public float MinSpawnRate => minSpawnRate;
        public float MaxSpawnRate => maxSpawnRate;
        public float SpawnRange => spawnRange;
        public int DifficultyIncreaseNumber => difficultyIncreaseNumber;
        public float DifficultyIncreaseMultipler => difficultyIncreaseMultipler;
        private void OnValidate()
        {
            if (minSpawnRate > maxSpawnRate)
                maxSpawnRate = minSpawnRate + 0.1f;

            if (maxSpawnRate <= minSpawnRate)
                maxSpawnRate = minSpawnRate + 0.1f;
        }
    }
}
