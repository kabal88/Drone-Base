using System;
using System.Collections.Generic;
using DroneBase.Interfaces;

namespace DroneBase.Services
{
    public class UpdateLocalService :IUpdatable
    {
        private readonly List<IUpdatable> _updatables;

        public UpdateLocalService()
        {
            _updatables = new List<IUpdatable>();
        }

        public void RegisterUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void UnRegisterUpdatable(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }

        public void UpdateLocal(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.UpdateLocal(deltaTime);
            }
        }
    }
}