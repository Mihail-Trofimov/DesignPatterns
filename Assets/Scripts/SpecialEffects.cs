using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class SpecialEffects: ObjectWithLifeTime<SpecialEffects>
    {
        [SerializeField] private float _lifeTime;
        public override event DisableAction<SpecialEffects> disableEvent;

        public override void DisableEventInvoke()
        {
            disableEvent?.Invoke(this);
        }
    }
}