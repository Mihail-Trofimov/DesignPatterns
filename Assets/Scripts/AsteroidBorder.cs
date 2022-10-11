using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Unit asteroid = collision.GetComponent<Unit>();
            asteroid.Demolition();
        }
    }
}