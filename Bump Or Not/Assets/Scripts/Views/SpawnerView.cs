using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Views
{
    public class SpawnerView : MonoBehaviour
    {
        public static event Action<SpawnerView> OnDifficultyAmountSpawned;

        private Transform _spawnerTransform;
        private Coroutine _spawningCoroutine;

        private Pooler<ObstacleView> _obstaclePooler;
        private Pooler<PlayerCollectableView> _collectablesPooler;

        private float _spawnRange;
        private float _minSpawnRate = 1f;
        private float _maxSpawnRate = 2f;
        private int _difficultyIncreaseAmount = 20;

        private int _spawnedTimes = 0;

        private void Awake() => _spawnerTransform = transform;


        public void Initialize(Pooler<ObstacleView> obstaclePooler, Pooler<PlayerCollectableView> collectablePooler,
            float spawnRange, float minSpawnRate, float maxSpawnRate, int difficultyIncreaseAmount)
        {
            _obstaclePooler = obstaclePooler;
            _collectablesPooler = collectablePooler;

            if (_minSpawnRate > 0)
                _minSpawnRate = minSpawnRate;

            if (maxSpawnRate > 0)
                _maxSpawnRate = maxSpawnRate;

            if (spawnRange > 0)
                _spawnRange = spawnRange;

            if (difficultyIncreaseAmount > 0)
                _difficultyIncreaseAmount = difficultyIncreaseAmount;
        }
        public void AdjustSpawnRate(float multiplier)
        {
            _minSpawnRate *= multiplier;
            _maxSpawnRate *= multiplier;
        }
        public void StartSpawning()
        {
            StopSpawning();

            if (_obstaclePooler)
                _spawningCoroutine = StartCoroutine(Spawning());
        }
        public void StopSpawning()
        {
            if (_spawningCoroutine != null)
                StopCoroutine(_spawningCoroutine);
        }
        private IEnumerator Spawning()
        {
            while (gameObject.activeInHierarchy)
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.65)
                    SpawnObstacle();

                else SpawnCollectable();

                yield return new WaitForSeconds(GetSpawnRate());
            }
        }

        private void SpawnCollectable()
        {
            if (_collectablesPooler)
            {
                GameObject spawnedObject = _collectablesPooler.GetObject().gameObject;
                spawnedObject.transform.position = GetSpawnPosition();
                spawnedObject.transform.rotation = Quaternion.identity;
                spawnedObject.SetActive(true);

                ObjectSpawned();
            }
        }
        private void SpawnObstacle()
        {
            if (_obstaclePooler)
            {
                GameObject spawnedObject = _obstaclePooler.GetObject().gameObject;
                spawnedObject.transform.position = GetSpawnPosition();
                spawnedObject.transform.rotation = Quaternion.identity;
                spawnedObject.SetActive(true);

                ObjectSpawned();
            }
        }

        private void ObjectSpawned()
        {
            _spawnedTimes++;
            if (_spawnedTimes % _difficultyIncreaseAmount == 0)
                OnDifficultyAmountSpawned?.Invoke(this);
        }

        private float GetSpawnRate() => UnityEngine.Random.Range(_minSpawnRate, _maxSpawnRate);

        private Vector3 GetSpawnPosition()
        {
            Vector3 spawnPos = _spawnerTransform.position;
            spawnPos.x += UnityEngine.Random.Range(-_spawnRange, _spawnRange);
            spawnPos.y += UnityEngine.Random.Range(-_spawnRange, _spawnRange);
            spawnPos.z += UnityEngine.Random.Range(-_spawnRange, _spawnRange);

            return spawnPos;
        }
    }
}
