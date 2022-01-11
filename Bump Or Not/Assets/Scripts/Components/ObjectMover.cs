using UnityEngine;

public abstract class ObjectMover : MonoBehaviour, IMover
{
    protected Transform _moverTransform;
    protected float _moveSpeed = 1f;
    protected Vector3 _currentDirection;
    protected bool _canMove = true;

    protected virtual void Awake() => _moverTransform = transform;
    public void Initialize(Vector3 direction, float movementSpeed = -1)
    {
        if (movementSpeed > 0)
            _moveSpeed = movementSpeed;

        if (direction != Vector3.zero)
            _currentDirection = direction;
    }

    public void SetDirection(Vector3 direction) => Initialize(direction);
    public void SetMoveSpeed(float movementSpeed) => Initialize(Vector3.zero, movementSpeed);
    public void ToggleMovement(bool canMove) => _canMove = canMove;
}
