using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitModel: IMove, IRotate, IEntityType
    {
        public Vector3? PreviousTarget { get; }
        public TargetData CurrentTargetData { get; }
        void SetTargetData(TargetData data);
    }
}