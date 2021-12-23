using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Views
{
    public class DroneView : MonoBehaviour, IDroneView
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public Transform Transform => transform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
    }
}