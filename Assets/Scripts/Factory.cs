using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static class Factory
    {
        public static T Create<T>(T prefab) where T: MonoBehaviour
        {
            T gameObject = Object.Instantiate(prefab);
            return gameObject;
        }
        public static T Create<T>(string path) where T : MonoBehaviour
        {
            T prefab = Resources.Load<T>(path);
            return Create(prefab);
        }
    }
}