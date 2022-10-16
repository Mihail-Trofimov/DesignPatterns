using UnityEngine;

namespace Asteroids
{
    public sealed class BlasterSpecialEffects
    {
        private const int _defaultSizePool = 10;
        private const int _maxSizePool = 100;
        private static readonly SpecialEffect _prefab = Resources.Load<SpecialEffect>(Constant.PREFAB_SPECIAL_EFFECT_BLASTER);

        private static readonly Pool<SpecialEffect> _pool = new Pool<SpecialEffect>
            (
                Constant.NAME_POOL_BLASTER_EFFECTS,
                _prefab,
                _defaultSizePool,
                _maxSizePool
            );

        public static SpecialEffect Get(Vector2 position)
        {
            SpecialEffect effect = _pool.Get();
            effect.transform.position = position;
            return effect;
        }

    }
}