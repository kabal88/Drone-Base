using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneGivingState : UnitStateBase
    {
        private IResourceReceiver _receiver;
        public DroneGivingState(IDroneController drone, IResourceReceiver receiver) : base(drone)
        {
            _receiver = receiver;
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneGivingState");
            
            if (_receiver is ITargetable targetable)
                Drone.AbilitiesSystem.ExecuteAbility(Drone, DroneAbility.Give, targetable.GetTarget);
            ExitState();
            Drone.SetState(new DroneIdleState(Drone));
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneGivingState");
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
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}