using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Interfaces;

namespace DroneBase.Systems
{
    public class SpawnSystem : ISpawnSystem
    {
        private List<ISpawnPointController> _pointControllers = new List<ISpawnPointController>();

        public SpawnSystem()
        {
            
        }
        
        public IEnumerable<ISpawnPointController> GetSpawnPointsByPredicate(Func<ISpawnPointController, bool> predicate)
        {
            return _pointControllers.Where(predicate);
        }
    }
}