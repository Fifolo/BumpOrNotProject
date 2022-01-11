using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PoolReturner : MonoBehaviour
{
    private void Awake() => GetComponent<Collider>().isTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        IPoolable poolable = other.GetComponentInParent<IPoolable>();
        if (poolable != null)
            poolable.ReturnToPool();
    }
}
