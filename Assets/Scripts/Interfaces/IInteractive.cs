using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IInteractive
    {
        Vector3 InteractivePoint { get; }

        void SetInteractivePoint(Vector3 point);
    }
}