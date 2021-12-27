using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IAimable
    {
        void SetTarget(ITarget target);
        void SetTarget(Vector3 point);
    }
}