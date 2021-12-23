using System.Collections.Generic;
using DroneBase.Interfaces;

namespace DroneBase.Services
{
    public class FixUpdateLocalService :IFixUpdatable
    {
        private readonly List<IFixUpdatable> _updatables;

        public FixUpdateLocalService()
        {
            _updatables = new List<IFixUpdatable>();
        }

        public void RegisterUpdatable(IFixUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void UnRegisterUpdatable(IFixUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }
        
        public void FixedUpdateLocal()
        {
            foreach (var updatable in _updatables)
            {
                updatable.FixedUpdateLocal();
            }
        }
    }
}