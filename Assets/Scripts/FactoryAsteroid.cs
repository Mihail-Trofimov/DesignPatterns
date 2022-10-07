using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class FactoryAsteroid : IFactory<Asteroid>
    {
        public Asteroid Create(string path)
        {
            Asteroid prefab = Resources.Load<Asteroid>(path);
            Asteroid unit = Create(prefab);
            return unit;
        }

        public Asteroid Create(Asteroid prefab)
        {
            return Object.Instantiate(prefab);
        }
    }
}