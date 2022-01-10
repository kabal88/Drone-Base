using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneAlertState : UnitStateBase
    {
        public DroneAlertState(IDroneController context) : base(context)
        {
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneAlertState");
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneAlertState");
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
        }
    }
}