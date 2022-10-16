using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class Pool<T> where T : DisabledObject<T>
    {
        private readonly IObjectPool<T> _pool;
        private readonly Transform _parent;
        private readonly T _prefab;

        public Pool(string poolName, T prefab, int defaultSize, int maxSize)
        {
            _parent = new GameObject(poolName).transform;
            _prefab = prefab;
            const bool collectionChecks = false;
            _pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, defaultSize, maxSize);
        }

        private T CreatePooledItem()
        {
            T disabledObject = Factory.Create<T>(_prefab);
            disabledObject.disableEvent += Release;
            disabledObject.transform.SetParent(_parent);
            return disabledObject;
        }

        private void OnTakeFromPool(T disabledObject)
        {
            disabledObject.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(T disabledObject)
        {
            disabledObject.transform.localPosition = Vector3.zero;
            disabledObject.transform.localRotation = Quaternion.identity;
            disabledObject.gameObject.SetActive(false);
        }

        void OnDestroyPoolObject(T disabledObject)
        {
            disabledObject.disableEvent -= OnReturnedToPool;
            Object.Destroy(disabledObject.gameObject);
        }

        public T Get()
        {
            return _pool.Get();
        }

        private void Release(T disabledObject)
        {
            _pool.Release(disabledObject);
        }
    }
}