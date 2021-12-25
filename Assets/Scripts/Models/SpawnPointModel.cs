using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public sealed class SpawnPointModel : ISpawnPointModel
    {
        public bool IsBlocked { get; private set; }
        public Vector3 PointPosition { get;private set; }
        public Quaternion PointRotation { get; private set;}
        public EntityType PointType { get; private set;}
        public SpawnPointData PointData => new SpawnPointData(PointPosition, PointRotation);

        public SpawnPointModel(SpawnPointDescription description)
        {
            IsBlocked = description.IsBlocked;
            PointPosition = description.PointData.Position;
            PointRotation = description.PointData.Rotation;
            PointType = description.PointType;
        }

        public void SetIsBlocked(bool isBlocked)
        {
            IsBlocked = isBlocked;
        }

        public void SetPointPosition(Vector3 position)
        {
            PointPosition = position;
        }

        public void SetPointRotation(Quaternion rotation)
        {
            PointRotation = rotation;
        }

        public void SetPointType(EntityType type)
        {
            PointType = type;
        }
    }
}