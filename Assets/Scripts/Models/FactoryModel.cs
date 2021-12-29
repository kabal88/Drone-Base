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
        public Vector3 InteractivePoint { get; private set; }

        public FactoryModel(EntityType type, Vector3 interactivePoint = default, Vector3 position = default, Quaternion rotation = default)
        {
            Type = type;
            InteractivePoint = interactivePoint;
            Position = position;
            Rotation = rotation;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetInteractivePoint(Vector3 point)
        {
            InteractivePoint = point;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }

    }
}