using System;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct SpawnPointData
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public SpawnPointData(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}