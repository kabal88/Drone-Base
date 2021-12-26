using System;

namespace DroneBase.Interfaces
{
    public interface ISelectable : IEntityType
    {
        event Action<ISelectable> Selected;

        void SetSelection();
        void ClearSelection();
    }
}