using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IDroneDescription : IDescription
    {
        GameObject DronePrefab { get; }
        IDroneModel DroneModel { get; }
    }
}