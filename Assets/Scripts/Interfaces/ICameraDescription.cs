using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICameraDescription :IDescription
    {
        GameObject CameraPrefab { get; }
        ICameraModel CameraModel { get; }
    }
}