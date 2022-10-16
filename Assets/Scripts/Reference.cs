using UnityEngine;

namespace Asteroids
{
    public sealed class Reference
    {

        private Player _player;
        private Camera _mainCamera;
        private GameLoop _gameLoop;
        private AsteroidSpawn _spawnAsteroid;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Factory.Create<Player>(Constant.PREFAB_PLAYER);
                }
                return _player;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public AsteroidSpawn SpawnerAsteroid
        {
            get
            {
                if (_gameLoop == null)
                {
                    _spawnAsteroid = Factory.Create<AsteroidSpawn>(Constant.PREFAB_SPAWN_ASTEROID);
                }
                return _spawnAsteroid;
            }
        }

    }
}

