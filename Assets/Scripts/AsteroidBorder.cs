using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Unit asteroid = collision.GetComponent<Unit>();
            asteroid.Demolition();
        }
    }
}