using System;
using UnityEngine;
using System.Collections;

namespace Views
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMover))]
    public class PlayerView : CollidableObject, IPlayerView, IDestructable
    {
        #region Events
        public delegate void PlayerMovementEvent(float zPosition, out float movementInput);
        public static event PlayerMovementEvent OnPlayerUpBeingHeld;
        public static event PlayerMovementEvent OnPlayerDownBeingHeld;

        public static event Action<PlayerView, Vector3> OnPlayerFireBeingHeld;
        public static event Action<PlayerView, bool> OnPlayerSpacePressed;
        public static event Action<PlayerView, CollidableObject> OnPlayerCollision;
        public static event Action<PlayerView, IPlayerCollectable> OnCollectableCollision;

        public delegate void PlayerScaleEvent(PlayerView player, float currentScale);
        public static event PlayerScaleEvent OnPlayerGrowPressed;
        public static event PlayerScaleEvent OnPlayerShrinkPressed;
        #endregion

        [SerializeField] Animator anim;

        [Header("Input settings")]
        [SerializeField] KeyCode LeftTrigger;
        [SerializeField] KeyCode RightTrigger;
        [SerializeField] KeyCode FireTrigger;
        [SerializeField] KeyCode JumpTrigger;
        [SerializeField] KeyCode GrowTrigger;
        [SerializeField] KeyCode ShrinkTrigger;

        [SerializeField] private float GravityForce = 9.81f;

        private static readonly int DIE_TRIGGER = Animator.StringToHash("Die");

        private IMover _mover;

        private float _movementSpeed = 5f;
        private float _movementInput = 0;
        private bool IsOnGround = true;
        [HideInInspector]
        public bool ListenForInput = false;

        protected override void Awake()
        {
            base.Awake();
            _mover = GetComponent<IMover>();
            _rb.useGravity = false;
        }

        void Update()
        {
            _movementInput = 0;

            if (ListenForInput)
            {
                ListenForShootingInput();

                ListenForJumpInput();

                ListenForScaleChangeInput();

                ListenForMovementInput();
            }
        }

        private void ListenForShootingInput()
        {
            if (Input.GetKey(FireTrigger))
                OnPlayerFireBeingHeld?.Invoke(this, Vector3.right);
        }

        private void ListenForJumpInput()
        {
            if (Input.GetKeyDown(JumpTrigger))
                OnPlayerSpacePressed?.Invoke(this, IsOnGround);
        }

        private void ListenForScaleChangeInput()
        {
            if (Input.GetKey(GrowTrigger))
                OnPlayerGrowPressed?.Invoke(this, _transform.localScale.x);

            if (Input.GetKey(ShrinkTrigger))
                OnPlayerShrinkPressed?.Invoke(this, _transform.localScale.x);
        }

        private void ListenForMovementInput()
        {
            if (Input.GetKey(LeftTrigger))
                OnPlayerUpBeingHeld?.Invoke(_transform.position.z, out _movementInput);

            else if (Input.GetKey(RightTrigger))
                OnPlayerDownBeingHeld?.Invoke(_transform.position.z, out _movementInput);
        }

        void FixedUpdate()
        {
            Move();
            ApplyGravity();
        }

        private void Move()
        {
            if (_movementInput != 0)
            {
                _mover.Initialize(Vector3.forward * _movementInput, _movementSpeed);
                _mover.ToggleMovement(true);
            }

            else _mover.ToggleMovement(false);
        }

        private void ApplyGravity()
        {
            if (!IsOnGround)
                _rb.AddForce(Vector3.down * GravityForce, ForceMode.Acceleration);
        }

        public void Jump(float jumpForce) => _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        public void Grow(float multiplier) => ChangeLocalScale(multiplier);
        public void Shrink(float multiplier) => ChangeLocalScale(multiplier);
        public void AdjustMovementSpeed(float multiplier) => _movementSpeed *= multiplier;
        public override void Destroy() => anim.SetTrigger(DIE_TRIGGER);

        private void ChangeLocalScale(float multiplier)
        {
            _transform.localScale *= multiplier;
            SetCollisionForce();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IPlayerCollectable playerCollectible))
                OnCollectableCollision?.Invoke(this, playerCollectible);

            if (collision.gameObject.CompareTag("Ground"))
                IsOnGround = true;

            if (collision.transform.TryGetComponent(out CollidableObject obj))
                OnPlayerCollision?.Invoke(this, obj);
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                IsOnGround = false;
        }
        public void Initialize(float movementSpeed)
        {
            if (movementSpeed > 0)
                _movementSpeed = movementSpeed;
        }
        public void IncreaseMovementSpeed(float multiplier, float duration)
        {
            StartCoroutine(ApplyBoost(
                () => _movementSpeed *= multiplier, 
                duration, 
                () => _movementSpeed /= multiplier));
        }
        public void ChangeCollisionForce(float multiplier, float duration)
        {
            StartCoroutine(ApplyBoost(
                () => _collisionForce *= multiplier,
                duration,
                () => _collisionForce /= multiplier));
        }

        private IEnumerator ApplyBoost(Action OnBegin, float duration, Action OnFinish)
        {
            OnBegin.Invoke();
            yield return new WaitForSeconds(duration);
            OnFinish.Invoke();
        }
    }
}