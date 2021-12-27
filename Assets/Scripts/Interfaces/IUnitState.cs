using System;
using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitState : IState<IUnitController>
    {
        void SetTarget(ITarget target, IUnitModel model);
        void SetTarget(Vector3 point, IUnitModel model);
        void SetSelection(IUnitView view);
        void ClearSelection(IUnitView view);
        void OnViewSelected(ISelect obj, Action<ISelect> callback);
    }
}