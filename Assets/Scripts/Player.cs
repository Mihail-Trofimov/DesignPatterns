using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {

        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;

        public PlayerMovement Movement { get; private set; }

        private void Awake()
        {
            Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
            PlayerRotation _rotation = new PlayerRotation(transform);
            MoveRigidBodyAcceleration _move = new MoveRigidBodyAcceleration(_rigidBody, _speed, _acceleration);
            Movement = new PlayerMovement(_rotation, _move);
        }

    }
}