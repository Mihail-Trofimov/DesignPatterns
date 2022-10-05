using System;
using System.Collections;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ammunition : MonoBehaviour
    {
        [SerializeField] private int DamageDealt;
        public Rigidbody2D RigidBody { get; private set; }

        public delegate void Action(Ammunition ammunition);
        public event Action disableEvent;

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
            yield return new WaitForSeconds(2.5f);
            disableEvent.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamage heatPoint = collision.GetComponent<Unit>();
            heatPoint.Damage(DamageDealt);
            disableEvent.Invoke(this);
        }

    }
}