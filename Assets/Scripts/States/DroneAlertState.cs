using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneAlertState : UnitStateBase
    {
        public DroneAlertState(IUnitController context) : base(context)
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

        public override void SetTarget(ITarget target, IUnitModel model)
        {
            throw new NotImplementedException();
        }

        public override void SetTarget(Vector3 point, IUnitModel model)
        {
            throw new NotImplementedException();
        }

        public override void SetSelection(IUnitView view)
        {
            throw new NotImplementedException();
        }

        public override void ClearSelection(IUnitView view)
        {
            throw new NotImplementedException();
        }

        public override void OnViewSelected(ISelect obj, Action<ISelect> callback)
        {
            throw new NotImplementedException();
        }
    }
}