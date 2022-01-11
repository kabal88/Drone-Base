using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneAlertState : UnitStateBase
    {
        private ITarget _targetBase;
        public DroneAlertState(IDroneController context, ITarget targetBase) : base(context)
        {
            _targetBase = targetBase;
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneAlertState");
            Context.MoveSystem.SetDestination(_targetBase.TargetData.Point);
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

        public override void OnSensorCollide(Collider other)
        {
            if (!other.TryGetComponent<IActionArea>(out var obj)) return;

            var view = obj.GetView;
            if (view.Id != Context.Model.CurrentTargetData.Id) return;
            
            CustomDebug.Log($"Sensor Collide");
            
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