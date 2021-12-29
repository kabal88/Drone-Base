using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IWarehouseModel : IBuildingModel,IInteractive, IResourceStorage
    {
        public TargetData GetTargetData { get; }
    }
}