using System;

namespace DroneBase.Interfaces
{
    public interface ISelectionService : IRepository<ISelectable>
    {
        event Action<ISelect> Selected;
    }
}