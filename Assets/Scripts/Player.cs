using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : Unit
    {
        [SerializeField] private int _maxHealthPoint;

        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;

        [SerializeField] private Transform _launcher;
        [SerializeField] private float _ammunitionAcceleration;
        [SerializeField] private float _weaponReloadTime;
        [SerializeField] private Ammunition _ammunitionPrefab;

        public PlayerMovement Movement { get; private set; }
        public Weapon Weapon { get; private set; }

        public override event Action destroyEvent;

        private void Awake()
        {
            Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
            PlayerRotation _rotation = new PlayerRotation(transform);
            MoveRigidBodyAcceleration _move = new MoveRigidBodyAcceleration(_rigidBody, _speed, _acceleration);
            Movement = new PlayerMovement(_rotation, _move);
            Weapon = new Weapon(Constant.NAME_POOL_PLAYER_BLASTER, _launcher, _ammunitionAcceleration, _weaponReloadTime, _ammunitionPrefab);
            Health = new Health(_maxHealthPoint);
        }

        public override void Demolition()
        {
            destroyEvent.Invoke(this);
        }

        public override void Execute()
        {
            Weapon.Execute();
        }

    }
}