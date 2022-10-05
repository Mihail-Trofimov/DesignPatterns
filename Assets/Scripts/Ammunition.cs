using System.Collections;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ammunition : MonoBehaviour
    {
        [SerializeField] private int DamageDealt;
        public Rigidbody2D RigidBody { get; private set; }

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
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
            yield return new WaitForSeconds(2.5f);
            MakeInactive();
        }

        private void MakeInactive()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamage heatPoint = collision.GetComponent<Unit>();
            heatPoint.Damage(DamageDealt);
            MakeInactive();
        }

    }
}