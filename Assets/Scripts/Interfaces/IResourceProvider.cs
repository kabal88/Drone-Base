using System;
using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IResourceProvider
    {
        event Action<ResourcesContainer> ResourcesProvide;
        ResourcesContainer GetResources(int quantity);
    }
}