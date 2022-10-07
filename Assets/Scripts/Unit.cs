using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour, IDamage, IExecute
    {
        public delegate void Action(Unit unit);
        public abstract event Action destroyEvent;

        public Health Health { get; protected set; }

        public void Damage(int damage)
        {
            Health.Damage(damage);
            if (Health.IsDemolition) Demolition();
        }

        public abstract void Demolition();

        public abstract void Execute();
    }
}