using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Systems
{
    public class NavMeshMovingSystem : IMoveSystem
    {
        private NavMeshAgent _navMeshAgent;

        public NavMeshMovingSystem(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }


        public void SetDestination(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
        }
    }
}