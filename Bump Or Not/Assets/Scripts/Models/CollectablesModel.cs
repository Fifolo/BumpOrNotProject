using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName ="Models/CollectablesModel")]
    public class CollectablesModel : ScriptableObject
    {
        [Header("Speed")]
        [Min(1f)]
        [SerializeField] float moveSpeedTime = 2f;
        [SerializeField] float moveSpeedMultiplier = 2f;
        [Header("Score")]
        [SerializeField] float scoreInrease = 10f;
        [Header("Collision Force")]
        [Range(0.1f, 2f)]
        [SerializeField] float collisionMultiplier = 0.9f;
        [Min(1)]
        [SerializeField] float collisionChangeTime = 1f;

        public float MoveSpeedTime => moveSpeedTime;
        public float ScoreInrease => scoreInrease;
        public float MoveSpeedMultiplier => moveSpeedMultiplier;
        public float CollisionMultiplier => collisionMultiplier;
        public float CollisionChangeTime => collisionChangeTime;
    }
}