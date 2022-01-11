using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Pooler<T> : MonoBehaviour where T : MonoBehaviour
{
    public static event Action<Pooler<T>> OnPoolerStart;

    protected T defaultPrefab;
    protected List<T> _freeList;
    protected List<T> _usedList;

    protected Transform _poolerTransform;

    private void Awake() => _poolerTransform = transform;
    private void Start() => OnPoolerStart?.Invoke(this);

    public void Initialze(List<T> prefabs, int amount)
    {
        defaultPrefab = prefabs[0];

        _freeList = new List<T>();
        _usedList = new List<T>();

        foreach (T prefab in prefabs)
        {
            for (int i = 0; i < amount; i++)
            {
                T spawnedPrefab = Instantiate(prefab, _poolerTransform);
                spawnedPrefab.gameObject.SetActive(false);
                _freeList.Add(spawnedPrefab);
            }
        }
    }
    public T GetObject()
    {
        T objectToReturn;

        if (_freeList.HasItems())
        {
            objectToReturn = _freeList.GetRandomItem();
            _freeList.Remove(objectToReturn);
        }
        else
        {
            objectToReturn = Instantiate(defaultPrefab, transform.position, Quaternion.identity);
            objectToReturn.gameObject.SetActive(false);
        }

        _usedList.Add(objectToReturn);
        return objectToReturn;
    }
    public void ReturnObject(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        _usedList.Remove(objectToReturn);
        _freeList.Add(objectToReturn);
    }
}