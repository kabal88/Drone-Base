using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface INavigable
    {
        void SetNavTarget(Vector3 target);
    }
}