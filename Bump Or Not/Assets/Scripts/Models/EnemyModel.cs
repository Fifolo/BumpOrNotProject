using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/EnemyModel")]
    public class EnemyModel : ScriptableObject
    {
        [Min(0f)]
        [SerializeField] float movementSpeed = 5f;
        [Min(1f)]
        [SerializeField] float maxHealth = 5f;

        public float MovementSpeed => movementSpeed;
        public float MaxHealth => maxHealth;
    }
}