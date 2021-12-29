using System;
using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IResourceReceiver
    {
        event Action<ResourcesContainer> ResourcesReceived;
        void TakeResources(ResourcesContainer container);
    }
}