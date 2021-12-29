using DroneBase.Data;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IAimable
    {
        void SetTarget(TargetData target);
    }
}