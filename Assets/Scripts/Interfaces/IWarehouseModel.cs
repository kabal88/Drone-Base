using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IWarehouseModel : IBuildingModel, IInteractive, IResourceStorage
    {
        ResourceType StorageResourceType { get; }
        int StorageResourceQuantity { get; }
    }
}