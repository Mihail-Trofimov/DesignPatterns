using UnityEngine;

namespace Asteroids
{
    public sealed class InputController : IExecute, IFixExecute
    {

        private Vector2 _position;
        private Vector3 _direction;

        private readonly PlayerMovement _playerMovement;
        private readonly Transform _playerTransform;
        private readonly Weapon _playerWeapon;
        private readonly Camera _camera;

        public InputController(Player player, Camera camera)
        {
            _playerTransform = player.transform;
            _playerMovement = player.Movement;
            _playerWeapon = player.Weapon;
            _camera = camera;
        }

        public void Execute()
        {
            _position.x = Input.GetAxis(Constant.HORIZONTAL);
            _position.y = Input.GetAxis(Constant.VERTICAL);

            _direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerTransform.position);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerMovement.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerMovement.RemoveAcceleration();
            }

            if (Input.GetButton(Constant.FIRE1))
            {
                _playerWeapon.Shoot();
            }
        }

        public void FixExecute()
        {
            _playerMovement.Rotation(_direction);
            _playerMovement.Move(_position.x, _position.y, Time.deltaTime);
        }
    }
}