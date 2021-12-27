using System;

namespace DroneBase.Interfaces
{
    public interface ITargetable: IEntityType
    {
        event Action<ITarget> Targeted;
        public ITarget GetTarget { get; }
    }
}