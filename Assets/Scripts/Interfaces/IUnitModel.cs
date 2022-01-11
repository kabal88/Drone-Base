using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitModel: IMove, IRotate, IEntityType, IIdentifier
    {
        public TargetData PreviousTarget { get; }
        public TargetData CurrentTarget { get; }
        IUnitState PreviousState { get; }
        void SetTargetData(TargetData data);
        void SetPreviousState(IUnitState state);
    }
}