using System;
using System.Collections;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ammunition : ObjectWithLifeTime<Ammunition>
    {
        public override event DisableAction<Ammunition> disableEvent;

        [SerializeField] private int _damageDealt;

        public Rigidbody2D RigidBody { get; private set; }

        [SerializeField] private float _lifeTime;

        //public void SetLifeTime(float lifeTime)
        //{
        //    _lifeTime = lifeTime;
        //}

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }

        //private void OnEnable()
        //{
        //    StartCoroutine(DisableObjectFromTimer());
        //}
        //private void OnDisable()
        //{
        //    StopCoroutine(DisableObjectFromTimer());
        //}

        //private IEnumerator DisableObjectFromTimer()
        //{
        //    yield return new WaitForSeconds(_lifeTime);
        //    DisableEventInvoke();
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamage heatPoint = collision.GetComponent<Unit>();
            heatPoint.Damage(_damageDealt);
            DisableEventInvoke();
        }

        public override void DisableEventInvoke()
        {
            disableEvent?.Invoke(this);
        }

    }
}