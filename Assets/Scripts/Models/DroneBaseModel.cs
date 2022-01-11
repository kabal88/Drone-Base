using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public class DroneBaseModel : IDroneBaseModel
    {
        public EntityType Type { get; }
        public int Id { get; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public TargetData GetTargetData => new TargetData(Position, Type, Id);


        public DroneBaseModel(EntityType type, Vector3 position = default, Quaternion rotation = default)
        {
            Id = IDGenerator.GetNewId(this);
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