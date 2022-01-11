using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : ObjectMover
{
    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(_canMove)
            rb.MovePosition(_moverTransform.position + _currentDirection * _moveSpeed * Time.fixedDeltaTime);
    }
}
