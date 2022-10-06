using System;
using System.Collections;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ammunition : MonoBehaviour
    {
        [SerializeField] private int _damageDealt;
        public Rigidbody2D RigidBody { get; private set; }

        public delegate void Action(Ammunition ammunition);
        public event Action disableEvent;
        private float _lifeTime = 2.5f;

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(DisableObjectFromTimer());
        }
        private void OnDisable()
        {
            StopCoroutine(DisableObjectFromTimer());
        }

        private IEnumerator DisableObjectFromTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            disableEvent.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamage heatPoint = collision.GetComponent<Unit>();
            heatPoint.Damage(_damageDealt);
            disableEvent.Invoke(this);
        }

    }
}