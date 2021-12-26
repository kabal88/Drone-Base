using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IBuildingModel: IEntityType
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }

        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}