using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerMovement : IRotation, IMove
    {

        private readonly IRotation _rotation;
        private readonly IMove _move;

        public float Speed => _move.Speed;

        public PlayerMovement(IRotation rotation, IMove move)
        {
            _rotation = rotation;
            _move = move;
        }

        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }

        public void AddAcceleration()
        {
            if (_move is MoveRigidBodyAcceleration accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_move is MoveRigidBodyAcceleration accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

    }
}