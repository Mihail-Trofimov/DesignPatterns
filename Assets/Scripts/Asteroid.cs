using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Asteroid : Unit, IRotate
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private int _force;
        [SerializeField] private Transform _body;
        [SerializeField] private int _damageDealt;
        private Rigidbody2D _rigidBody;

        public override event Action destroyEvent;

        public override void Demolition()
        {
            destroyEvent?.Invoke(this);
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
            if (collision.tag == Constant.TAG_PLAYER)
            {
                IDamage heatPoint = collision.GetComponent<Unit>();
                heatPoint.Damage(_damageDealt);
                Demolition();
            }
        }

        public override void Execute()
        {
            Rotate();
        }

        public void Rotate()
        {
            _body.transform.Rotate(0f, 0f, _speedRotate * Time.deltaTime);
        }

    }
}