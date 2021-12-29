using UnityEngine.AI;

namespace DroneBase.Interfaces
{
    public interface INavMeshAgent
    {
        NavMeshAgent NavMeshAgent { get; }
        void SetNavMeshSettings(float speed, float rotationSpeed);
    }
}