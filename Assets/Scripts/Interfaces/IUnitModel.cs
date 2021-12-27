using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitModel: IMove, IRotate, IEntityType
    {
        public Vector3? PreviousTarget { get; }
        public Vector3 CurrentTarget { get; }
        void SetTarget(Vector3 target);
    }
}