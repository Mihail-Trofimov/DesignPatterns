using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public delegate void DisableAction<T>(T gameObject) where T : MonoBehaviour;
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