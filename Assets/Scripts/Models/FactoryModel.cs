using UnityEngine;
using DroneBase.Enums;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class FactoryModel :IFactoryModel
    {
        public EntityType Type { get; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public FactoryModel(EntityType type, Vector3 position = default, Quaternion rotation = default)
        {
            Type = type;
            Position = position;
            Rotation = rotation;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }
    }
}