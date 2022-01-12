using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitModel: IMove, IRotate, IEntityType, IIdentifier
    {
        bool InSaveArea { get; }
        TargetData PreviousTarget { get; }
        TargetData CurrentTarget { get; }
        IUnitState PreviousState { get; }
        void SetTargetData(TargetData data);
        void SetPreviousState(IUnitState state);
        void SetInSaveArea(bool inSave);
    }
}