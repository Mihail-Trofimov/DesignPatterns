using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class DisabledObject<T> : MonoBehaviour, IDisengageability<T> where T: MonoBehaviour
    {
        public abstract event DisableAction<T> disableEvent;
        public abstract void DisableEventInvoke();
    }
}