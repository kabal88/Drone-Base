using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Data
{
    public struct TargetData
    {
        public Vector3 Point { get; }

        public TargetData(Vector3 point)
        {
            Point = point;
        }

    }
}