using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneGivingState : UnitStateBase
    {
        public DroneGivingState(IUnitController context, IResourceReceiver receiver) : base(context)
        {
        }

        public override void EnterState()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExitState()
        {
            throw new NotImplementedException();
        }

        public override void SetTarget(TargetData target, IUnitModel model)
        {
            throw new NotImplementedException();
        }

        public override void SetSelection(ISelectionView view)
        {
            throw new NotImplementedException();
        }

        public override void ClearSelection(ISelectionView view)
        {
            throw new NotImplementedException();
        }

        public override void OnViewSelected(ISelect obj, Action<ISelect> callback)
        {
            throw new NotImplementedException();
        }

        public override void OnSensorCollide(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void FixedUpdateLocal()
        {
            throw new NotImplementedException();
        }
    }
}