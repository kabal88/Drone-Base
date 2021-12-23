using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IRotate
    {
        Quaternion Rotation { get; }
        void SetRotation(Quaternion rotation);
        float RotationSpeed { get; }
    }
}