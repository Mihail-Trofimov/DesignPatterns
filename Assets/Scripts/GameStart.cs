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
            SpawnAsteroid spawner = reference.SpawnerAsteroid;
            GameLoop gameLoop = reference.GameLoop;

            gameLoop.AddExecute(input);
            gameLoop.AddExecute(player);
            gameLoop.AddExecute(spawner);

            gameLoop.AddFixExecute(input);
        }
    }
}