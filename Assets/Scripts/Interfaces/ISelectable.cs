using System;

namespace DroneBase.Interfaces
{
    public interface ISelectable
    {
        event Action<ISelectable> Selected;

        void SetSelection();
        void ClearSelection();
    }
}