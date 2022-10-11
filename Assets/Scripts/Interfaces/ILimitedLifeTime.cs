using System;
using System.Collections;
using UnityEngine;

namespace Asteroids
{

    public delegate void DisableAction<T>(T gameObject) where T: MonoBehaviour;
    public interface ILimitedLifeTime<T> where T : MonoBehaviour
    {
        public event DisableAction<T> disableEvent;
        public void SetLifeTime(float lifeTime);
    }
}