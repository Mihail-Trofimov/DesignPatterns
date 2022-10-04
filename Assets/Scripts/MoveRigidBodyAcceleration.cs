using UnityEngine;

namespace Asteroids
{
    internal sealed class MoveRigidBodyAcceleration : MoveRigidBody
    {
        private readonly float _acceleration;

        public MoveRigidBodyAcceleration(Rigidbody2D rigidBody, float speed, float acceleration): base(rigidBody, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
