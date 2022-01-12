using System;
using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitState : IState<IDroneController>, IFixUpdatable
    {
        void SetTarget(TargetData data, IUnitModel model);
        void SetSelection(ISelectionView view);
        void ClearSelection(ISelectionView view);
        void OnViewSelected(ISelect obj, Action<ISelect> callback);
        void OnSensorEnterTrigger(Collider other);
        void OnSensorExitTrigger(Collider other);
    }
}