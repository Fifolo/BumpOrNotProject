using UnityEngine;

public class TransformMover : ObjectMover
{
    private void Update()
    {
        if (_canMove)
            _moverTransform.Translate(_currentDirection * _moveSpeed * Time.deltaTime);
    }
}
