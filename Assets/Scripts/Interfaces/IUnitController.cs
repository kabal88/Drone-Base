using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitController: IAimable, ISelectable, ISelect, IUnitContext
    {
        public Vector3? PreviousTarget { get; }
        void SetState(IUnitState state);
    }
}