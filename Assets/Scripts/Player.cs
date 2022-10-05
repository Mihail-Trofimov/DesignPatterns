using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : Unit, IExecute
    {

        [SerializeField] private int _maxHealthPoint;

        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;

        [SerializeField] Transform _launcher;
        [SerializeField] float _ammunitionAcceleration;
        [SerializeField] float _weaponReloadTime;
        [SerializeField] Ammunition _ammunitionPrefab;

        public PlayerMovement Movement { get; private set; }
        public Weapon Weapon { get; private set; }

        private void Awake()
        {
            Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
            PlayerRotation _rotation = new PlayerRotation(transform);
            MoveRigidBodyAcceleration _move = new MoveRigidBodyAcceleration(_rigidBody, _speed, _acceleration);
            Movement = new PlayerMovement(_rotation, _move);
            Weapon = new Weapon(_launcher, _ammunitionAcceleration, _weaponReloadTime, _ammunitionPrefab);
            Health = new Health(100);
        }

        public override void Demolition()
        {
            Debug.Log("Game Over");
        }

        public void Execute()
        {
            Weapon.Execute();
        }

    }
}