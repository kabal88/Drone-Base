using System;

namespace DroneBase.Interfaces
{
    public interface ITargetable
    {
        event Action<ITargetable> Targeted;
    }
}