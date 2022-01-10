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

        public DroneHarvestingState(IDroneController context, IResourceProvider provider) : base(context)
        {
            _provider = provider;
        }

        public override void EnterState()
        {
            CustomDebug.Log($"Enter state DroneHarvestingState");
            if (_provider is ITargetable targetable)
                Context.AbilitiesSystem.ExecuteAbility(Context, DroneAbility.Collect, targetable.GetTarget);
            ExitState();
            Context.SetState(new DroneIdleState(Context));
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

        public override void OnSensorCollide(Collider other)
        {
        }

        public override void FixedUpdateLocal()
        {
        }
    }
}