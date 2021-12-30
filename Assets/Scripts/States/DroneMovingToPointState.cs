using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneMovingToPointState : UnitStateBase
    {
        public DroneMovingToPointState(IUnitController context) : base(context)
        {
        }

        public override void EnterState()
        {
            ServiceLocator.Get<IFixUpdateService>().RegisterObject(this);
            Context.MoveSystem.SetDestination(Context.Model.CurrentTargetData.Point);
        }

        public override void Execute()
        {
        }

        public override void ExitState()
        {
            ServiceLocator.Get<IFixUpdateService>().UnRegisterObject(this);
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
            CheckReachDestination();
        }

        public override void SetTarget(TargetData target, IUnitModel model)
        {
            switch (target.Type)
            {
                case EntityType.None:
                case EntityType.Unit:
                    model.SetTargetData(target);
                    Context.MoveSystem.SetDestination(target.Point);
                    break;
                case EntityType.Building:
                    model.SetTargetData(target);
                    ExitState();
                    Context.SetState(new DroneMovingToBuildingState(Context));
                    break;
                case EntityType.Camera:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void CheckReachDestination()
        {
            if (!Context.MoveSystem.IsReachDestination) return;
            
            ExitState();
            Context.SetState(new DroneIdleState(Context));
        }
    }
}