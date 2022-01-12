using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using DroneBase.States;

namespace DroneBase.Controllers
{
    public sealed class PlayerController : IDisposable
    {
        private readonly IPlayerModel _model;
        private readonly IInputSystem _inputSystem;
        private readonly ICanvasController _canvas;

        private PlayerController(
            IPlayerModel playerModel,
            IInputSystem inputSystem,
            ICanvasController canvas)
        {
            _inputSystem = inputSystem;
            _canvas = canvas;
            _model = playerModel;
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

            foreach (var drone in model.AllDrones)
            {
                drone.EnterSaveArea += player.CheckAllInSaveAndCloseGates;
            }

            return player;
        }

        private void CheckAllInSaveAndCloseGates()
        {
            var result = true;
            foreach (var drone in _model.AllDrones)
            {
                if (!drone.IsInSaveArea)
                {
                    result = false;
                }
            }

            if (result)
            {
                foreach (var droneBase in _model.AllDroneBase)
                {
                    droneBase.SetGate(false);
                }
            }
        }

        private void OnSelected(ISelect obj)
        {
            _model.SelectedObject?.ClearSelection();

            _model.SetSelectedObject(obj);
            obj.SetSelection();
        }

        private void SetTarget(CustomRaycastHit hit)
        {
            if (!(_model.SelectedObject is IAimable aimable)) return;

            aimable.SetTarget(hit.HasTargetable
                ? hit.Targetable.GetTarget.TargetData
                : new TargetData(hit.Point, EntityType.None));
        }

        public void SetSelectedUnit(IUnitController selected)
        {
            _model.SetSelectedObject(selected);
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

            var alarm = !_model.IsAlarmOn;

            _model.SetIsAlarmOn(alarm);
            _canvas.SetAlarm(alarm);

            foreach (var droneBase in _model.AllDroneBase)
            {
                droneBase.SetGate(true);
            }
            
            if (alarm)
            {
                foreach (var drone in _model.AllDrones)
                {
                    drone.SetState(new DroneAlertState(drone, _model.AllDroneBase.First()));
                }
            }
            else
            {
                foreach (var drone in _model.AllDrones)
                {
                    drone.PreviousState();
                }
            }
        }
    }
}