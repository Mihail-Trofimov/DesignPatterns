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

            GameLoop gameLoop = reference.GameLoop;

            spawner.Initialization(gameLoop);
            gameLoop.AddExecute(spawner);

            gameLoop.AddExecute(input);
            gameLoop.AddFixExecute(input);

            gameLoop.AddExecute(player);

        }
    }
}