using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public abstract class ObjectWithLifeTime<T> : DisabledObject<T> where T: MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        public float LifeTime
        {
            get{ return _lifeTime; }
            set{ _lifeTime = value; }
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
            yield return new WaitForSeconds(LifeTime);
            DisableEventInvoke();
        }
    }
}