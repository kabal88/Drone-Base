using System;
using System.Collections.Generic;

namespace DroneBase.Interfaces
{
    public interface ISelectionService : IRepository<ISelectable>, ISelectable
    {
    }
}