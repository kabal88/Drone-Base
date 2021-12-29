using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneMovingToBuildingState : UnitStateBase
    {
        public DroneMovingToBuildingState(IUnitController context) : base(context)
        {
        }

        public override void EnterState()
        {
            
        }

        public override void Execute()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void SetTarget(TargetData target, IUnitModel model)
        {
            throw new NotImplementedException();
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
            if (!other.TryGetComponent<IIdentifier>(out var obj)) return;
            if (obj.Id != Context.Model.CurrentTargetData.Id) return;
            
            switch (obj)
            {
                case IResourceGiver giver:
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