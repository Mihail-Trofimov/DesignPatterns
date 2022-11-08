using UnityEngine;

namespace Asteroids
{
    public sealed class GameStart : MonoBehaviour
    {
        private void Awake()
        {
<<<<<<< Updated upstream
=======
            Ammunition prefabBlasterPlayer = Resources.Load<Ammunition>(Constant.PREFAB_AMMUNITION_PLAYER_BLASTER);
            const int defaultPoolSize = 20;
            const int maxPoolSize = 30;
            Pool<Ammunition> ammunitionPool = new Pool<Ammunition>(Constant.NAME_POOL_PLAYER_BLASTER, prefabBlasterPlayer, defaultPoolSize, maxPoolSize);

            PoolServiceLocator.Add(Constant.NAME_POOL_PLAYER_BLASTER, ammunitionPool);

>>>>>>> Stashed changes
            Reference reference = new Reference();
            Player player = reference.Player;
            Camera camera = reference.MainCamera;
            InputController input = new InputController(player, camera);
            AsteroidSpawn spawner = reference.SpawnerAsteroid;
            GameController gameController = new GameController(player);

            //GameLoop gameLoop = reference.GameLoop;
            //GameLoop gameLoop = new GameLoop();

            GameLoopSingleton.AddExecute(spawner);

            GameLoopSingleton.AddExecute(input);
            GameLoopSingleton.AddFixExecute(input);

<<<<<<< Updated upstream
            gameLoop.AddExecute(player);
            gameLoop.AddFixExecute(player);
=======
            GameLoopSingleton.AddExecute(player);
>>>>>>> Stashed changes

        }
    }
}