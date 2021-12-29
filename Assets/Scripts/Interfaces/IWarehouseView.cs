using System;

namespace DroneBase.Interfaces
{
    public interface IWarehouseView : IBuildingView<IWarehouseController,IWarehouseModel>, IInteractive, IResourceGiver
    {
        event Action<IResourceReceiver> AskedForResources;
    }
}