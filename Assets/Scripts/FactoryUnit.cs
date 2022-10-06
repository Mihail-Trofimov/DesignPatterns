using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class FactoryUnit: IFactory<Unit>
    {
        public Unit Create(string path)
        {
            Unit prefab = Resources.Load<Unit>(path);
            Unit unit = Create(prefab);
            return unit;

        }

        public Unit Create(Unit prefab)
        {
            return Object.Instantiate(prefab);
        }
    }
}