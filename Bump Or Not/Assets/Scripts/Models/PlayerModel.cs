using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/PlayerModel")]
    public class PlayerModel : ScriptableObject
    {
        [Min(1f)]
        [SerializeField] float jumpForce = 10;
        [Min(1f)]
        [SerializeField] float baseMoveSpeed = 10;
        [Min(1)]
        [SerializeField] float maxScale = 2;
        [Min(0.3f)]
        [SerializeField] float minScale = 0.5f;
        [Range(0.001f, 0.01f)]
        [SerializeField] float growMulitplier = 0.001f;
        [Range(0.001f, 0.01f)]
        [SerializeField] float shrinkMulitplier = 0.001f;

        public float JumpForce => jumpForce;
        public float BaseMoveSpeed => baseMoveSpeed;
        public float MaxScale => maxScale;
        public float MinScale => minScale;
        public float GrowMultiplier => growMulitplier;
        public float ShrinkMultiplier => shrinkMulitplier;
        public bool CanShrink(float currentScale) => currentScale > minScale;
        public bool CanGrow(float currentScale) => currentScale < maxScale;
        public float ZBound => 2f;
    }
}