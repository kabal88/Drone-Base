using System.Collections.Generic;
using DroneBase.Interfaces;
using DroneBase.Libraries;

namespace DroneBase.Models
{
    public class GameModel
    {
        public IUpdatable UpdateService { get; private set; }
        public IFixUpdatable FixUpdateService { get; private set; }
        private Library Library { get; }

        public GameModel(Library library)
        {
            Library = library;
        }

        public void SetUpdateService(IUpdatable service)
        {
            UpdateService = service;
        }

        public void SetFixUpdateService(IFixUpdatable service)
        {
            FixUpdateService = service;
        }
    }
}