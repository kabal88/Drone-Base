using System;
using System.Collections.Generic;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using Sirenix.Utilities;

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
            _inputSystem.RightMouseButtonClick += SetTarget;
        }

        public static PlayerController CreatePlayerController(
            IPlayerDescription description,
            IInputSystem inputSystem, List<IUnitController> units = default)
        {
            var model = description.PlayerModel;

            if (!units.IsNullOrEmpty())
            {
                foreach (var unit in units)
                {
                    model.AddUnit(unit);
                }
            }

            var player = new PlayerController(description.PlayerModel, inputSystem);
            ServiceLocator.Get<ISelectionService>().Selected += player.OnSelected;
            return player;
        }

        private void OnSelected(ISelect obj)
        {
            _playerModel.SelectedObject?.ClearSelection();

            _playerModel.SetSelectedObject(obj);
            obj.SetSelection();
        }

        private void SetTarget(CustomRaycastHit hit)
        {
            if (!(_playerModel.SelectedObject is IAimable aimable)) return;
            
            if (hit.Targetable == null)
            {
                aimable.SetTarget(hit.Point);
            }
            else
            {
                aimable.SetTarget(hit.Targetable.GetTarget);
            }
        }

        public void SetSelectedUnit(IUnitController selected)
        {
            _playerModel.SetSelectedObject(selected);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().Selected -= OnSelected;
            _inputSystem.RightMouseButtonClick -= SetTarget;
        }
    }
}