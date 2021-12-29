using DroneBase.Data;
using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IWarehouseModel : IBuildingModel,IInteractive, IResourceStorage
    {
        public TargetData GetTargetData { get; }
        public ResourceType StorageResourceType { get; }
        public int StorageResourceQuantity { get; }
    }
}