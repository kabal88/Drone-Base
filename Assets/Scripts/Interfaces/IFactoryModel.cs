using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IFactoryModel : IBuildingModel, IInteractive, IResourceStorage
    {
        public TargetData GetTargetData { get; }
    }
}