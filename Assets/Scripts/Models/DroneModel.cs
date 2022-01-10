using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public sealed class DroneModel : IDroneModel
    {
        public int Id { get; }
        public float Speed { get; }
        public float RotationSpeed { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public Vector3? PreviousTarget { get; private set; }
        public TargetData CurrentTargetData { get; private set; }
        public Quaternion Rotation { get; private set; }
        public EntityType Type { get; }
        public ResourcesContainer Container { get; private set; }


        public DroneModel(MoveData moveData, RotationData rotationData, EntityType type)
        {
            Id = IDGenerator.GetNewId(this);
            Type = type;
            Speed = moveData.Speed;
            Position = moveData.Position;
            RotationSpeed = rotationData.RotationSpeed;
            Rotation = Quaternion.Euler(rotationData.Rotation);
            PreviousTarget = null;
        }

        public void SetTargetData(TargetData data)
        {
            PreviousTarget = CurrentTargetData.Point;
            CurrentTargetData = data;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }

        public void SetResourcesContainer(ResourcesContainer container)
        {
            CustomDebug.Log($"Take container with {container.Type} - {container.Quantity}");
            Container = container;
        }
    }
}