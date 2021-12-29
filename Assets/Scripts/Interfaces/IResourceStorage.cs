using DroneBase.Data;
using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IResourceStorage
    {
        void AddResource(ResourcesContainer container);
        bool TryGetResource(ResourcesContainer container, out int qty);
        bool TryGetQuantityOfResource(ResourceType type, out int qty);
    }
}