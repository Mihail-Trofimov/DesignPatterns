using UnityEngine;


namespace Asteroids
{
    public sealed class SpawnerAsteroid : ISpawner
    {
        private readonly Asteroid[] _prefabsArray;
        private readonly Transform[] _spawnPointsArray;
        private readonly Transform[] _targetPointsArray;
        private readonly IFactory<Asteroid> _factory;
        private readonly Transform _parent;
        private readonly GameLoop _gameLoop;

        public SpawnerAsteroid(GameLoop gameLoop, Asteroid[] prefabsArray, Transform[] spawnPointsArray, Transform[] targetPointsArray)
        {
            _gameLoop = gameLoop;
            _prefabsArray = prefabsArray;
            _spawnPointsArray = spawnPointsArray;
            _targetPointsArray = targetPointsArray;
            _factory = new FactoryAsteroid();
            _parent = new GameObject(Constant.NAME_ASTEROIDS).transform;
        }

        public void DestroyUnit(Unit unit)
        {
            unit.destroyEvent -= DestroyUnit;
            _gameLoop.RemoveExecute(unit);
            Object.Destroy(unit.gameObject);
        }

        public void Spawn()
        {
            Asteroid asteroid = _factory.Create(RandomPrefab());
            asteroid.destroyEvent += DestroyUnit;
            _gameLoop.AddExecute(asteroid);
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