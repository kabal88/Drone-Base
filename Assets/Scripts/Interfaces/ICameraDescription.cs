using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICameraDescription :IDescription
    {
        ICameraModel CameraModel { get; }
        GameObject CameraPrefab { get; }
    }
}