using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class AmmunitionPool
    {
        private readonly IObjectPool<Ammunition> _pool;
        private readonly Transform _parent;
        private readonly Ammunition _prefab;

        public AmmunitionPool(string poolName, Ammunition prefab, Action<Ammunition> OnTakeFromPool, int defaultSize, int maxSize)
        {
            _parent = new GameObject(poolName).transform;
            _prefab = prefab;
            const bool collectionChecks = true;
            _pool = new ObjectPool<Ammunition>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, defaultSize, maxSize);
        }

        private Ammunition CreatePooledItem()
        {
            Ammunition ammo = Object.Instantiate(_prefab);
            ammo.disableEvent += Release;
            ammo.transform.SetParent(_parent);
            return ammo;
        }

        private void OnReturnedToPool(Ammunition ammo)
        {
            ammo.RigidBody.velocity = new Vector3(0, 0, 0);
            ammo.transform.localPosition = Vector3.zero;
            ammo.transform.localRotation = Quaternion.identity;
            ammo.gameObject.SetActive(false);
        }

        void OnDestroyPoolObject(Ammunition ammo)
        {
            ammo.disableEvent -= OnReturnedToPool;
            Object.Destroy(ammo.gameObject);
        }

        public Ammunition Get()
        {
            return _pool.Get();
        }

        private void Release(Ammunition ammo)
        {
            _pool.Release(ammo);
        }
    }
}