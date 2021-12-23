using System;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct SpawnPointData
    {
        public Vector3 PointPosition;
        public Quaternion Rotation;
    }
}