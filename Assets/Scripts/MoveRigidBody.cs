using UnityEngine;

namespace Asteroids
{
    public class MoveRigidBody : IMove
    {

        private readonly Rigidbody2D _rigidBody;
        public float Speed { get; protected set; }

        public MoveRigidBody(Rigidbody2D rigidBody, float speed)
        {
            _rigidBody = rigidBody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            float speed = deltaTime * Speed;
            Vector2 direction = new Vector2(horizontal, vertical);
            direction.Normalize();
            _rigidBody.AddForce(direction * speed, ForceMode2D.Impulse);
        }

    }
}
