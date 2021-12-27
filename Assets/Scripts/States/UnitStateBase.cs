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
        public abstract void SetTarget(ITarget target, IUnitModel model);
        public abstract void SetTarget(Vector3 point, IUnitModel model);
        public abstract void SetSelection(IUnitView view);
        public abstract void ClearSelection(IUnitView view);
        public abstract void OnViewSelected(ISelect obj, Action<ISelect> callback);

    }
}