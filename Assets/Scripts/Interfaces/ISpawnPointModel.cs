using DroneBase.Data;
using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface ISpawnPointModel
    {
        bool IsBlocked { get; }
        SpawnPointData PointData { get; }
        EntityType PointType { get; }
        
        void SetIsBlocked(bool isBlocked);
        void SetPointData(SpawnPointData data);
    }
}