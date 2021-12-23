using System;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class PlayerController : IDisposable
    {
        private IPlayerModel _playerModel;
        private IInputSystem _inputSystem;

        public PlayerController(IInputSystem inputSystem, IPlayerModel playerModel)
        {
            _inputSystem = inputSystem;
            _playerModel = playerModel;
            _inputSystem.RightMouseButtonClickPoint += SetTarget;
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