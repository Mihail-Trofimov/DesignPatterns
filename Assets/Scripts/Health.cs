using UnityEngine;

namespace Asteroids
{
    public sealed class Health : IDamage
    {
        public int Max { get; }
        public int Current { get; private set; }
        public bool IsDemolition { get; private set; } = false;

        public Health(int maxHealthPoint)
        {
            Current = maxHealthPoint;
            Max = maxHealthPoint;
        }

        public Health(int maxHealthPoint, int healthPoint)
        {
            Max = maxHealthPoint;
            Current = healthPoint;
        }

        public void SetHealth(int healthPoint)
        {
            Current = healthPoint;
        }

        public void Damage(int damage)
        {
            Current -= damage;
            if (Current <= 0) Demolition();
        }

        public void Demolition()
        {
            IsDemolition = true;
            Current = 0;
        }

        public void Resurrect()
        {
            IsDemolition = false;
            SetHealth(Max);
        }

    }
}