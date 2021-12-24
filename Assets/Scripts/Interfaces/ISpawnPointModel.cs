using UnityEngine;
using DroneBase.Data;
using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface ISpawnPointModel
    {
        bool IsBlocked { get; }
        public Vector3 PointPosition{ get; }
        public Quaternion PointRotation{ get; }
        EntityType PointType { get; }
        public SpawnPointData PointData { get; }
        
        void SetIsBlocked(bool isBlocked);
        void SetPointPosition(Vector3 position);
        void SetPointRotation(Quaternion rotation);
        void SetPointType(EntityType type);
    }
}