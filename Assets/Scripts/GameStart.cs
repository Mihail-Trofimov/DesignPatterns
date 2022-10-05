using UnityEngine;

namespace Asteroids
{
    public sealed class GameStart : MonoBehaviour
    {

        private GameLoop _gameLoop;
        private Player _player;
        private Camera _camera;
        private InputController _input;
        private Reference _reference;

        private void Awake()
        {
            _reference = new Reference();
            _player = _reference.Player;
            _camera = _reference.MainCamera;
            _gameLoop = _reference.GameLoop;

            _input = new InputController(_player, _camera);
            _gameLoop.AddExecute(_input);
            _gameLoop.AddFixExecute(_input);
            _gameLoop.AddExecute(_player);
        }

    }
}