using System;
using System.Collections.Generic;

namespace DroneBase.Interfaces
{
    public interface ISpawnSystem
    {
        IEnumerable<ISpawnPointController> GetSpawnPointsByPredicate(Func<ISpawnPointController, bool> predicate);
    }
}