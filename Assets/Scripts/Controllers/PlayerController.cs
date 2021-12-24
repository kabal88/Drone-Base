using System;
using DroneBase.Descriptions;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class PlayerController : IDisposable
    {
        private IPlayerModel _playerModel;
        private IInputSystem _inputSystem;
        private ICameraController _cameraController;

        private PlayerController(
            IPlayerModel playerModel,
            IInputSystem inputSystem,
            ICameraController cameraController
        )
        {
            _inputSystem = inputSystem;
            _playerModel = playerModel;
            _cameraController = cameraController;
            _inputSystem.RightMouseButtonClickPoint += SetTarget;
        }

        public static PlayerController CreatePlayerController(
            IPlayerDescription description,
            IInputSystem inputSystem,
            ICameraController cameraController)
        {
            var player = new PlayerController(description.PlayerModel, inputSystem, cameraController);
            return player;
        }

        private void SetTarget(Vector3 target)
        {
            _playerModel.SelectedUnit?.SetTarget(target);
        }

        public void SetSelectedUnit(IUnitController selected)
        {
            _playerModel.SetSelectedUnit(selected);
        }

        public void Dispose()
        {
            _inputSystem.RightMouseButtonClickPoint -= SetTarget;
        }
    }
}