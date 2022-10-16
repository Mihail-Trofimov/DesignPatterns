using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public delegate void DisableAction<T>(T gameObject) where T : MonoBehaviour;
    public interface IDisengageability<T> where T : MonoBehaviour
    {
        event DisableAction<T> disableEvent;
        void DisableEventInvoke();
    }
}