using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneNormalState : UnitStateBase
    {
        public DroneNormalState(IUnitController context) : base(context)
        {
        }

        public override void EnterState()
        {
            if (Context.PreviousTarget == null) return;
            Context.MoveSystem.SetDestination((Vector3)Context.PreviousTarget);
        }

        public override void Execute()
        {
        }

        public override void ExitState()
        {
        }


        public override void SetTarget(Vector3 point, IUnitModel model)
        {
            model.SetTarget(point);
            Context.MoveSystem.SetDestination(point);
        }

        public override void SetSelection(IUnitView view)
        {
            view.SetSelection();
        }

        public override void ClearSelection(IUnitView view)
        {
            view.ClearSelection();
        }

        public override void OnViewSelected(ISelect obj, Action<ISelect> callback)
        {
            callback.Invoke(obj);
        }

        public override void SetTarget(ITarget target, IUnitModel model)
        {
            switch (target.Type)
            {
                case EntityType.None:
                    break;
                case EntityType.Unit:
                    break;
                case EntityType.Building:
                    break;
                case EntityType.Camera:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CustomDebug.Log($"Unit set target = {target.TargetData.Point}");
            SetTarget(target.TargetData.Point, model);
        }
    }
}