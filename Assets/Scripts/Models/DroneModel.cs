using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public sealed class DroneModel : IDroneModel
    {
        public bool InSaveArea { get; private set; }
        public int Id { get; }
        public float Speed { get; }
        public float RotationSpeed { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public TargetData PreviousTarget { get; private set; }
        public TargetData CurrentTarget { get; private set; }
        public Quaternion Rotation { get; private set; }
        public EntityType Type { get; }
        public ResourcesContainer Container { get; private set; }
        public IUnitState PreviousState { get; private set; }


        public DroneModel(MoveData moveData, RotationData rotationData, EntityType type)
        {
            Id = IDGenerator.GetNewId(this);
            Type = type;
            Speed = moveData.Speed;
            Position = moveData.Position;
            RotationSpeed = rotationData.RotationSpeed;
            Rotation = Quaternion.Euler(rotationData.Rotation);
            PreviousTarget = new TargetData();
        }

        public void SetTargetData(TargetData data)
        {
            PreviousTarget = CurrentTarget;
            CurrentTarget = data;
        }

        public void SetPreviousState(IUnitState state)
        {
            PreviousState = state;
        }

        public void SetInSaveArea(bool inSave)
        {
            InSaveArea = inSave;
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