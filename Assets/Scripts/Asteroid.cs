using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    //[RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : Unit
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private int _force;
        [SerializeField] private Transform _body;

        private Rigidbody2D _rigidBody;

        public override void Demolition()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            Animator animator = GetComponent<Animator>();
            animator.speed = _speedRotate;
            Health = new Health(_maxHealthPoint);
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        public void AddForce(Vector3 _direction)
        {
            _rigidBody.AddForce(_direction * _force, ForceMode2D.Impulse);
        }
    }
}