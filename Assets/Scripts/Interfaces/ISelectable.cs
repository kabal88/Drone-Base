using System;

namespace DroneBase.Interfaces
{
    public interface ISelectable : IEntityType
    {
        event Action<ISelect> Selected;
        public ISelect GetSelect { get; }
    }
}