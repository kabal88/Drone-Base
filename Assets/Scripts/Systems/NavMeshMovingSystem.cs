using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Systems
{
    public sealed class NavMeshMovingSystem : IMoveSystem
    {
        public bool IsReachDestination => IsAgentReachDestination();
        public float SqrVelocity => _navMeshAgent.velocity.sqrMagnitude;
        public float Acceleration { get; }

        private readonly NavMeshAgent _navMeshAgent;

        public NavMeshMovingSystem(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }
        
        public void SetDestination(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
        }

        private bool IsAgentReachDestination()
        {
            var result = false;
            
            if (!_navMeshAgent.pathPending)
            {
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                {
                    if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}