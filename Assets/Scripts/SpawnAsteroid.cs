using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class SpawnAsteroid : MonoBehaviour, IExecute
    {
        [SerializeField] private Asteroid[] _prefabsArray;
        [SerializeField] private Transform[] _spawnPointsArray;
        [SerializeField] private Transform[] _targetPointsArray;
        [SerializeField] private float _timerFrom;
        [SerializeField] private float _timerTo;
        private float _timer = 2;
        private IFactory<Asteroid> _factory;
        
        private Transform _parent;
        

        private void Awake()
        {
            _factory = new FactoryAsteroid();
            _parent = new GameObject(Constant.NAME_ASTEROIDS).transform;
        }

        public void Execute()
        {
            if(_timer<=0)
            { 
                _timer = Random.Range(_timerFrom, _timerTo);
                Spawn();
            }
            _timer -= Time.deltaTime;
        }

        private void Spawn()
        {
            Asteroid asteroid = _factory.Create(RandomPrefab());
            asteroid.transform.SetParent(_parent);
            Vector3 point = RandomPoint(_spawnPointsArray);
            asteroid.transform.position = point;
            Vector3 target = RandomPoint(_targetPointsArray);
            Vector2 direction = GetCourse(target, point);
            asteroid.AddForce(direction);
        }

        private Asteroid RandomPrefab()
        {
            int randomNumber = Random.Range(0, _prefabsArray.Length);
            return _prefabsArray[randomNumber];
        }

        private Vector3 RandomPoint(Transform[] points)
        {
            int randomNumber = Random.Range(0, points.Length);
            return points[randomNumber].position;
        }

        public Vector2 GetCourse(Vector3 target, Vector3 position)
        {
            Vector2 course = target - position;
            course.Normalize();
            return course;
        }

    }
}