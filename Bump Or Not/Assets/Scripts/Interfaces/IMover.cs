using UnityEngine;
public interface IMover
{
    public void Initialize(Vector3 direction, float movementSpeed);
    public void SetMoveSpeed(float movementSpeed);
    public void SetDirection(Vector3 direction);
    public void ToggleMovement(bool canMove);
}
