using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IDroneModel: IUnitModel
    {
        public ResourcesContainer Container { get; }
        void SetResourcesContainer(ResourcesContainer container);
    }
}