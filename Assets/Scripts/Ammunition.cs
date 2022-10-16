using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ammunition : ObjectWithLifeTime<Ammunition>, IDoingDamage
    {
        public override event DisableAction<Ammunition> disableEvent;
        [SerializeField] private int _damageDealt;

        public Rigidbody2D RigidBody { get; private set; }

        public int DamageDealt
        {
            get { return _damageDealt; }
            set { _damageDealt = value; }
        }

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            BlasterSpecialEffects.Get(transform.position);

            IHealth heatPoint = collision.GetComponent<Unit>();
            heatPoint.TakeDamage(DamageDealt);

            DisableEventInvoke();
        }

        public override void DisableEventInvoke()
        {
            RigidBody.velocity = new Vector3(0, 0, 0);
            disableEvent?.Invoke(this);
        }

    }
}