using UnityEngine;

namespace Asteroids
{
    public sealed class GameController
    {
        public GameController(Player player)
        {
            player.destroyEvent += LooseGame;
        }

        private void LooseGame(Unit player)
        {
            Debug.Log("GameOver");
        }

    }
}