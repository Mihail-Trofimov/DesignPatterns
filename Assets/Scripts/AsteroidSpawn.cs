using System;
using System.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawn : MonoBehaviour, IExecute
    {
        [SerializeField] private Asteroid[] _prefabsArray;
        [SerializeField] private Transform[] _spawnPointsArray;
        [SerializeField] private Transform[] _targetPointsArray;
        [SerializeField] private float _timerFrom;
        [SerializeField] private float _timerTo;
        private float _timer = 2;
        private ISpawner _spawner;

        public void Awake()
        {
            _spawner = new SpawnerAsteroid(_prefabsArray, _spawnPointsArray, _targetPointsArray);
        }

        public void Execute()
        {
            if(_timer<=0)
            { 
                _timer = Random.Range(_timerFrom, _timerTo);
                if(_spawner==null)
                {
                    throw new DataException(nameof(_spawner) + " not found");
                }
                _spawner.Spawn();
            }
            _timer -= Time.deltaTime;
        }

    }
}