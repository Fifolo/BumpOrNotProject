using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/ObstacleModel")]
    public class ObstacleModel : ScriptableObject
    {
        [Min(1f)]
        [SerializeField] float baseHealth = 10f;
        [Min(1f)]
        [SerializeField] float baseSpeed = 10f;
        [Range(1.01f, 2f)]
        [SerializeField] float difficultyIncreaseMultiplier = 1.1f;
        [Min(1)]
        [SerializeField] float maxScale = 2f;
        [Range(0f, 1f)]
        [SerializeField] float useGravityChance = 0.5f;
        public float BaseHealth => baseHealth;
        public float BaseSpeed => baseSpeed;
        public float DifficultyIncreaseMultiplier => difficultyIncreaseMultiplier;
        public float MaxScale => maxScale;
        public bool UseGravity => Random.Range(0f, 1f) <= useGravityChance;
    }
}
