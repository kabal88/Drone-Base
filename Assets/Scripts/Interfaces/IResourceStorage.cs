using DroneBase.Data;
using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IResourceStorage
    {
        void AddResource(ResourcesContainer container);
        int GetQuantityOfResource(ResourceType type);
    }
}