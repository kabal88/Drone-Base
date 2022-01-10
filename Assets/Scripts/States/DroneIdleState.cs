using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneIdleState : UnitStateBase
    {
        public DroneIdleState(IDroneController context) : base(context)
        {
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneIdleState");
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneIdleState");
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
                    Context.SetState(new DroneMovingToBuildingState(Context));
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
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}