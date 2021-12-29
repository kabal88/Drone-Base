using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Data
{
    public struct TargetData
    {
        public int Id { get; }
        public Vector3 Point { get; }
        public EntityType Type { get; }

        public TargetData(Vector3 point, EntityType type, int id = default)
        {
            Id = id;
            Point = point;
            Type = type;
        }
    }
}