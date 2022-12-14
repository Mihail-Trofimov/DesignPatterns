using UnityEngine;

namespace Asteroids
{
    public sealed class GameStart : MonoBehaviour
    {
        private void Awake()
        {
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