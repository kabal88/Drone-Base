using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Systems
{
    public sealed class NavMeshNavigationSystem: INavigationSystem
    {
        private NavMeshPath _path;

        public NavMeshNavigationSystem()
        {
            _path = new NavMeshPath();
        }

        public Vector3[] CalculatePath(Vector3 startPosition, Vector3 targetPosition)
        {
            NavMesh.CalculatePath(startPosition, targetPosition, NavMesh.AllAreas,_path);
            
            CustomDebug.Log($"CalculatePath, corners = {_path.corners.Length}");
            
            return _path.corners;
        }
    }
}