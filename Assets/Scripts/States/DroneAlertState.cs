using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneAlertState : UnitStateBase
    {
        private ITarget _targetBase;
        public DroneAlertState(IDroneController drone, ITarget targetBase) : base(drone)
        {
            _targetBase = targetBase;
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneAlertState");
            Drone.Model.SetTargetData(_targetBase.TargetData);
            Drone.MoveSystem.SetDestination(_targetBase.TargetData.Point);
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneAlertState");
        }

        public override void SetTarget(TargetData target, IUnitModel model)
        {
            
        }
        
        public override void SetSelection(ISelectionView view)
        {
            view.PlaySelectionAnimation();
        }

        public override void ClearSelection(ISelectionView view)
        {
            view.StopSelectionAnimation();
        }

        public override void OnViewSelected(ISelect obj, Action<ISelect> callback)
        {
            callback.Invoke(obj);
        }

        public override void OnSensorEnterTrigger(Collider other)
        {
            if (!other.TryGetComponent<IActionArea>(out var obj)) return;

            var view = obj.GetView;
            if (view.Id != Drone.Model.CurrentTarget.Id) return;
            CustomDebug.Log($"Sensor right Enter Trigger");

            if (view is ISaveArea)
            {
                Drone.SetInSaveArea(true);
            }
            
        }

        public override void OnSensorExitTrigger(Collider other)
        {
            if (!other.TryGetComponent<IActionArea>(out var obj)) return;

            var view = obj.GetView;

            if (view is ISaveArea)
            {
                Drone.SetInSaveArea(false);
            }
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}