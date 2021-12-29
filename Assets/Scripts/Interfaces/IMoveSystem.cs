using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IMoveSystem
    {
        public bool IsReachDestination { get; }
        void SetDestination(Vector3 destination);
    }
}