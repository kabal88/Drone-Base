using System;

namespace DroneBase.Interfaces
{
    public interface IWarehouseView : IBuildingView<IWarehouseController,IWarehouseModel>, IInteractive, IResourceProvider
    {
    }
}