using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class SpawnPointModel : ISpawnPointModel
    {
        public bool IsBlocked { get; }
        public SpawnPointData PointData { get; }
        public EntityType PointType { get; }

        public void SetIsBlocked(bool isBlocked)
        {
            throw new System.NotImplementedException();
        }

        public void SetPointData(SpawnPointData data)
        {
            throw new System.NotImplementedException();
        }
    }
}