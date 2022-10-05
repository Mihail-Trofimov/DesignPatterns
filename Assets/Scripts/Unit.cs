using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour, IDamage
    {
        public Health Health { get; protected set; }

        public void Damage(int damage)
        {
            Health.Damage(damage);
            Debug.Log(Health.Current);
            if (Health.IsDemolition) Demolition();
        }

        public abstract void Demolition();

    }
}