using System;
using System.Collections.Generic;

namespace DroneBase.Interfaces
{
    public interface ISpawnSystemService
    {
        IEnumerable<ISpawnPointController> GetSpawnPointsByPredicate(Func<ISpawnPointController, bool> predicate);
    }
}