using System;

namespace DroneBase.Interfaces
{
    public interface IDroneController : IUnitController, IResourceReceiver, IResourceProvider, IFixUpdatable
    {
        // event Action EnterSaveArea; 
        // void OnEnterSaveArea();
    }
}