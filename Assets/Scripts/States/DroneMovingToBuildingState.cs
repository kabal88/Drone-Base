using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneMovingToBuildingState : UnitStateBase
    {
        public DroneMovingToBuildingState(IDroneController drone) : base(drone)
        {
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneMovingToBuildingState");
            Drone.MoveSystem.SetDestination(Drone.Model.CurrentTarget.Point);
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneMovingToBuildingState");
        }

        public override void SetTarget(TargetData target, IUnitModel model)
        {
            switch (target.Type)
            {
                case EntityType.None:
                case EntityType.Unit:
                    model.SetTargetData(target);
                    ExitState();
                    Drone.SetState(new DroneMovingToPointState(Drone));
                    break;
                case EntityType.Building:
                    model.SetTargetData(target);
                    Drone.MoveSystem.SetDestination(target.Point);
                    break;
                case EntityType.Camera:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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

        public override void OnSensorCollide(Collider other)
        {
            if (!other.TryGetComponent<IActionArea>(out var obj)) return;

            var view = obj.GetView;
            if (view.Id != Drone.Model.CurrentTarget.Id) return;

            CustomDebug.Log($"Sensor Collide");
            
            switch (view)
            {
                case IResourceProvider giver:
                    ExitState();
                    Drone.SetState(new DroneHarvestingState(Drone, giver));
                    break;
                case IResourceReceiver receiver:
                    ExitState();
                    Drone.SetState(new DroneGivingState(Drone, receiver));
                    break;
                default:
                    ExitState();
                    Drone.SetState(new DroneIdleState(Drone));
                    break;
            }
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}