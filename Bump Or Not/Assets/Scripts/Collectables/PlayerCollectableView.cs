using Views;
using UnityEngine;
using System;

[RequireComponent(typeof(IMover))]
public abstract class PlayerCollectableView : CollidableObject, IPlayerCollectable, IPoolable
{
    public static event Action<PlayerCollectableView> OnCollectableStart;

    protected Pooler<PlayerCollectableView> _pooler;
    private IMover _mover;
    protected override void Awake()
    {
        base.Awake();
        _mover = GetComponentInChildren<IMover>();
        _mover.Initialize(Vector3.left, 5f);
    }
    private void Start() => OnCollectableStart?.Invoke(this);
    public void InitializePool(Pooler<PlayerCollectableView> pooler)
    {
        if (pooler)
            _pooler = pooler;
    }
    protected override void SetCollisionForce() => _collisionForce = 0;
    public override void Destroy()
    {
        if (_pooler)
            ReturnToPool();
        else Destroy(gameObject);
    }
    public abstract void Interact(PlayerView player);

    public void ReturnToPool()
    {
        if (_pooler)
            _pooler.ReturnObject(this);
    }
}
