using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface INavigationSystem
    {
        Vector3[] CalculatePath(Vector3 startPosition, Vector3 targetPosition);
    }
}