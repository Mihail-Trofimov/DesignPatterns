using UnityEngine;

namespace Asteroids
{
    internal sealed class Service : IService
    {
        public void Test()
        {
            Debug.Log(nameof(Service));
        }
    }
}