using System;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct MoveData
    {
        public Vector3 Position;
        public float Speed;
    }
}