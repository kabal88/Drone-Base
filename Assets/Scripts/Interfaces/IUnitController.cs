using System;
using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IUnitController: IAimable, ISelectable, ISelect, IUnitContext, IIdentifier
    {
        TargetData PreviousTarget { get; }
        void SetState(IUnitState state);
        void PreviousState();
    }
}