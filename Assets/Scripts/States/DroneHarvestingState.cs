using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public class DroneHarvestingState : UnitStateBase
    {
        private IResourceProvider _provider;

        public DroneHarvestingState(IDroneController drone, IResourceProvider provider) : base(drone)
        {
            _provider = provider;
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneHarvestingState");
            if (_provider is ITargetable targetable)
                Drone.AbilitiesSystem.ExecuteAbility(Drone, DroneAbility.Collect, targetable.GetTarget);
            ExitState();
            Drone.SetState(new DroneIdleState(Drone));
        }

        public override void ExitState()
        {
            CustomDebug.Log($"Exit state DroneHarvestingState");
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

        public override void OnSensorEnterTrigger(Collider other)
        {
        }

        public override void OnSensorExitTrigger(Collider other)
        {
            
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}