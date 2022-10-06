using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour, IUnit, IDamage
    {
        public Health Health { get; protected set; }

        public void Damage(int damage)
        {
            Health.Damage(damage);

            if (Health.IsDemolition) Demolition();
        }

        public abstract void Demolition();

    }
}