using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IBuildingModel: IEntityType, IIdentifier
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        TargetData GetTargetData { get; }

        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}