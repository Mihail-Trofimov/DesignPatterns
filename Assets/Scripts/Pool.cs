using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class Pool<T> where T : ObjectWithLifeTime<T>
    {
        private readonly IObjectPool<T> _pool;
        private readonly Transform _parent;
        private readonly T _prefab;

        public Pool(string poolName, T prefab, Action<T> OnTakeFromPool, int defaultSize, int maxSize)
        {
            _parent = new GameObject(poolName).transform;
            _prefab = prefab;
            const bool collectionChecks = false;
            _pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, defaultSize, maxSize);
        }

        private T CreatePooledItem()
        {
            T objectWithLifeTime = Factory.Create<T>(_prefab);
            objectWithLifeTime.disableEvent += Release;
            objectWithLifeTime.transform.SetParent(_parent);
            return objectWithLifeTime;
        }

        private void OnReturnedToPool(T objectWithLifeTime)
        {
            objectWithLifeTime.transform.localPosition = Vector3.zero;
            objectWithLifeTime.transform.localRotation = Quaternion.identity;
            objectWithLifeTime.gameObject.SetActive(false);
        }

        void OnDestroyPoolObject(T objectWithLifeTime)
        {
            objectWithLifeTime.disableEvent -= OnReturnedToPool;
            Object.Destroy(objectWithLifeTime.gameObject);
        }

        public T Get()
        {
            return _pool.Get();
        }

        private void Release(T objectWithLifeTime)
        {
            _pool.Release(objectWithLifeTime);
        }
    }
}