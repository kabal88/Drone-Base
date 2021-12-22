using System;
using System.Collections.Generic;
using DroneBase.Interfaces;

namespace DroneBase.Controllers
{
    public class GameController : IUpdatable, IFixUpdatable
    {
        private readonly List<IUpdatable> _updatables;
        private readonly List<IFixUpdatable> _fixUpdatables;

        public GameController()
        {
            _updatables = new List<IUpdatable>();
            _fixUpdatables = new List<IFixUpdatable>();
        }

        public void StartGame()
        {
            
        }

        public void UpdateLocal(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.UpdateLocal(deltaTime);
            }
        }

        public void FixedUpdateLocal()
        {
            foreach (var fixUpdatable in _fixUpdatables)
            {
                fixUpdatable.FixedUpdateLocal();
            }
        }
    }
}