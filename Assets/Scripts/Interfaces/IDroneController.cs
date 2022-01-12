using System;

namespace DroneBase.Interfaces
{
    public interface IDroneController : IUnitController, IResourceReceiver, IResourceProvider, IFixUpdatable
    {
        event Action EnterSaveArea; 
        bool IsInSaveArea { get; }
        void SetInSaveArea(bool inSave);
    }
}