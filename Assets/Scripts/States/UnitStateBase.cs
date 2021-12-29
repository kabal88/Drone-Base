using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.States
{
    public abstract class UnitStateBase :IUnitState
    {
        public IUnitController Context { get; }

        protected UnitStateBase(IUnitController context)
        {
            Context = context;
        }
        
        public abstract void EnterState();
        public abstract void Execute();
        public abstract void ExitState();
        public abstract void SetTarget(TargetData target, IUnitModel model);
        public abstract void SetSelection(ISelectionView view);
        public abstract void ClearSelection(ISelectionView view);
        public abstract void OnViewSelected(ISelect obj, Action<ISelect> callback);
        public abstract void OnSensorCollide(Collider other);
        public abstract void FixedUpdateLocal();
    }
}