using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollidableObject : MonoBehaviour, IDestructable
{
    public float CollisionForce => _collisionForce;

    protected Transform _transform;
    protected Rigidbody _rb;
    protected float _collisionForce = 0.5f;
    protected bool HasBoxCollider = false;

    private Renderer _renderer;

    protected virtual void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponentInChildren<Renderer>();

        if (_transform.GetChild(0).TryGetComponent(out BoxCollider boxCollider))
            HasBoxCollider = true;

        SetCollisionForce();
    }
    protected virtual void SetCollisionForce()
    {
        _collisionForce = _renderer.bounds.size.magnitude;
    }

    public abstract void Destroy();
}
