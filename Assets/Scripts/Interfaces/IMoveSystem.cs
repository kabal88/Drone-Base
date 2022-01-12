using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IMoveSystem
    {
        bool IsReachDestination { get; }
        float SqrVelocity { get; }
        float Acceleration { get; }
        void SetDestination(Vector3 destination);
    }
}