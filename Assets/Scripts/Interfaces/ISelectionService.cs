using System;

namespace DroneBase.Interfaces
{
    public interface ISelectionService : IRepository<ISelectable>
    {
        event Action<ISelectable> Selected;

        void ClearAllSelection();
    }
}