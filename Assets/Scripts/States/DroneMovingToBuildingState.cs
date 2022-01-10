using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneMovingToBuildingState : UnitStateBase
    {
        public DroneMovingToBuildingState(IDroneController context) : base(context)
        {
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneMovingToBuildingState");
            Context.MoveSystem.SetDestination(Context.Model.CurrentTargetData.Point);
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
                    Context.SetState(new DroneMovingToPointState(Context));
                    break;
                case EntityType.Building:
                    model.SetTargetData(target);
                    Context.MoveSystem.SetDestination(target.Point);
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
            CustomDebug.Log($"sensor find: {other.name}");
            if (!other.TryGetComponent<IActionArea>(out var obj)) return;

            var view = obj.GetView;
            CustomDebug.Log($"Collide with {obj.GetView.Id}");
            if (view.Id != Context.Model.CurrentTargetData.Id) return;
            CustomDebug.Log($"ID {view.Id} matched with {Context.Model.CurrentTargetData.Id}");
            
            switch (view)
            {
                case IResourceProvider giver:
                    ExitState();
                    Context.SetState(new DroneHarvestingState(Context, giver));
                    break;
                case IResourceReceiver receiver:
                    ExitState();
                    Context.SetState(new DroneGivingState(Context, receiver));
                    break;
                default:
                    ExitState();
                    Context.SetState(new DroneIdleState(Context));
                    break;
            }
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}