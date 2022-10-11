using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class ObjectWithLifeTime<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        public abstract event DisableAction<T> disableEvent;

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        private void OnEnable()
        {
            StartCoroutine(DisableObjectFromTimer());
        }

        private void OnDisable()
        {
            StopCoroutine(DisableObjectFromTimer());
        }

        private IEnumerator DisableObjectFromTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            DisableEventInvoke();
        }

        public abstract void DisableEventInvoke();

    }
}