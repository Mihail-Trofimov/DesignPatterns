using UnityEngine;

namespace Asteroids
{
    public sealed class Reference
    {

        private Player _player;
        private Camera _mainCamera;
        private GameLoop _gameLoop;
        private SpawnAsteroid _spawnAsteroid;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    Player player = Resources.Load<Player>(Constant.PREFAB_PLAYER);
                    _player = Object.Instantiate(player);
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

        public GameLoop GameLoop
        {
            get
            {
                if (_gameLoop == null)
                {
                    GameLoop gameLoop = Resources.Load<GameLoop>(Constant.PREFAB_GAME_LOOP);
                    _gameLoop = Object.Instantiate(gameLoop);
                }
                return _gameLoop;
            }
        }

        public SpawnAsteroid SpawnerAsteroid
        {
            get
            {
                if (_gameLoop == null)
                {
                    SpawnAsteroid spawnAsteroid = Resources.Load<SpawnAsteroid>(Constant.PREFAB_SPAWN_ASTEROID);
                    _spawnAsteroid = Object.Instantiate(spawnAsteroid);
                }
                return _spawnAsteroid;
            }
        }

    }
}

