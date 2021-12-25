using System;
using DroneBase.Descriptions;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public sealed class PlayerController : IDisposable
    {
        private IPlayerModel _playerModel;
        private IInputSystem _inputSystem;

        private PlayerController(
            IPlayerModel playerModel,
            IInputSystem inputSystem
        )
        {
            _inputSystem = inputSystem;
            _playerModel = playerModel;
            _inputSystem.RightMouseButtonClickPoint += SetNavTarget;
        }

        public static PlayerController CreatePlayerController(
            IPlayerDescription description,
            IInputSystem inputSystem)
        {
            var player = new PlayerController(description.PlayerModel, inputSystem);
            ServiceLocator.Get<ISelectionService>().Selected += player.OnSelected;
            return player;
        }

        private void OnSelected(ISelectable obj)
        {
            _playerModel.SelectedObject?.ClearSelection();
            
            _playerModel.SetSelectedObject(obj);
            obj.SetSelection();
        }

        private void SetNavTarget(Vector3 target)
        {
            if (_playerModel.SelectedObject is INavigable navigable)
            {
                navigable.SetNavTarget(target);
            }
        }

        public void SetSelectedUnit(IUnitController selected)
        {
            _playerModel.SetSelectedObject(selected);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().Selected -= OnSelected;
            _inputSystem.RightMouseButtonClickPoint -= SetNavTarget;
        }
    }
}