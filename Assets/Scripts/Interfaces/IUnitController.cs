using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitController: IAimable, ISelectable, ISelect, IUnitContext, IIdentifier
    {
        public Vector3? PreviousTarget { get; }
        void SetState(IUnitState state);
    }
}