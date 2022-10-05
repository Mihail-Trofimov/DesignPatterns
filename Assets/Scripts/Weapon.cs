using UnityEngine;

namespace Asteroids
{
    public sealed class Weapon : IWeapon, IExecute
    {
        private readonly Transform _launcher;
        private float _force;
        private float _reloadTime;
        private bool _isReloaded = false;
        private float _timerReloaded = 0f;
        private Transform _parent;
        private Ammunition _prefab;

        public Weapon(Transform launcher, float force, float reloadTime, Ammunition prefab)
        {
            _launcher = launcher;
            _force = force;
            _reloadTime = reloadTime;
            _parent = new GameObject(Constant.BLASTER_NAME).transform;
            _prefab = prefab;
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
                Ammunition ammo = Object.Instantiate(_prefab);
                ammo.transform.SetParent(_parent);
                ammo.transform.position = _launcher.position;
                ammo.transform.rotation = _launcher.rotation;
                ammo.RigidBody.AddForce(ammo.transform.right * _force, ForceMode2D.Force);
                _isReloaded = false;
            }
        }

    }
}