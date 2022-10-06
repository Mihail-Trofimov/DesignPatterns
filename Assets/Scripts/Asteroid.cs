using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : Unit
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private int _force;
        [SerializeField] private Transform _body;
        [SerializeField] private int _damageDealt;
        private Rigidbody2D _rigidBody;

        public override void Demolition()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            Health = new Health(_maxHealthPoint);
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        public void AddForce(Vector3 _direction)
        {
            _rigidBody.AddForce(_direction * _force, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                IDamage heatPoint = collision.GetComponent<Unit>();
                heatPoint.Damage(_damageDealt);
                Demolition();
            }
        }
    }
}