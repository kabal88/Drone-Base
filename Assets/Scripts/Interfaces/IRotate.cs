using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IRotate
    {
        float RotationSpeed { get; }
        Quaternion Rotation { get; }
        void SetRotation(Quaternion rotation);
    }
}