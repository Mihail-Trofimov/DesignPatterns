using UnityEngine;

namespace Asteroids
{
    public sealed class Weapon : IWeapon, IExecute
    {
        private readonly Transform _launcher;
        private readonly float _force;
        private readonly float _reloadTime;
        private bool _isReloaded = false;
        private float _timerReloaded = 0f;
        private readonly Pool<Ammunition> _pool;
        private readonly int _layer;

        public Weapon(string rootName, Transform launcher, float force, float reloadTime, int layer)
        {
            _launcher = launcher;
            _force = force;
            _reloadTime = reloadTime;
            //const int defaultPoolSize = 20;
            //const int maxPoolSize = 30;
            //_pool = new Pool<Ammunition>(rootName, prefab, defaultPoolSize, maxPoolSize);
            _pool = PoolServiceLocator.Get(rootName);
            _layer = layer;
        }

        public void Execute()
        {
            if (!_isReloaded)
            {
                if (_timerReloaded < _reloadTime)
                {
                    _timerReloaded += Time.deltaTime;
                }
                else
                {
                    _timerReloaded = 0;
                    _isReloaded = true;
                }
            }
        }

        public void Shoot()
        {
            if (_isReloaded)
            {
                Ammunition ammo = _pool.Get();
                ammo.transform.position = _launcher.position;
                ammo.transform.rotation = _launcher.rotation;
                ammo.RigidBody.AddForce(ammo.transform.right * _force, ForceMode2D.Force);
                ammo.gameObject.layer = _layer;
                _isReloaded = false;
            }
        }

    }
}