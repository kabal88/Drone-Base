using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using DroneBase.States;
using Sirenix.Utilities;

namespace DroneBase.Controllers
{
    public sealed class PlayerController : IDisposable
    {
        private IPlayerModel _playerModel;
        private IInputSystem _inputSystem;
        private ICanvasController _canvas;

        private PlayerController(
            IPlayerModel playerModel,
            IInputSystem inputSystem,
            ICanvasController canvas)
        {
            _inputSystem = inputSystem;
            _canvas = canvas;
            _playerModel = playerModel;
            _inputSystem.RightMouseButtonClick += SetTarget;
        }

        public static PlayerController CreatePlayerController(
            IPlayerDescription description,
            IInputSystem inputSystem,
            ICanvasController canvasController,
            List<IUnitController> units = default,
            List<IBuildingController> buildings = default)
        {
            var model = description.PlayerModel;

            if (units != null)
            {
                foreach (var unit in units)
                {
                    model.AddUnit(unit);
                }
            }

            if (buildings != null)
            {
                foreach (var build in buildings)
                {
                    model.AddBuilding(build);
                }
            }


            var player = new PlayerController(model, inputSystem, canvasController);

            ServiceLocator.Get<ISelectionService>().Selected += player.OnSelected;
            canvasController.AlarmClicked += player.OnAlarmed;

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

            aimable.SetTarget(hit.HasTargetable
                ? hit.Targetable.GetTarget.TargetData
                : new TargetData(hit.Point, EntityType.None));
        }

        public void SetSelectedUnit(IUnitController selected)
        {
            _playerModel.SetSelectedObject(selected);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().Selected -= OnSelected;
            _canvas.AlarmClicked -= OnAlarmed;
            _inputSystem.RightMouseButtonClick -= SetTarget;
        }

        private void OnAlarmed()
        {
            CustomDebug.Log($"Alarm pressed!");

            var alarm = !_playerModel.IsAlarmOn;

            _playerModel.SetIsAlarmOn(alarm);
            _canvas.SetAlarm(alarm);

            foreach (var droneBase in _playerModel.AllDroneBase)
            {
                droneBase.SetGate(true);
            }
            
            if (alarm)
            {
                foreach (var drone in _playerModel.AllDrones)
                {
                    drone.SetState(new DroneAlertState(drone, _playerModel.AllDroneBase.First()));
                }
            }
            else
            {
                foreach (var drone in _playerModel.AllDrones)
                {
                    drone.PreviousState();
                }
            }
        }
    }
}