using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour, IHealth, IExecute
    {
        public delegate void Action(Unit unit);
        public abstract event Action destroyEvent;

        public Health Health { get; protected set; }

        public void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
            if (Health.IsDemolition) Demolition();
        }

        public abstract void Demolition();

        public abstract void Execute();
    }
}