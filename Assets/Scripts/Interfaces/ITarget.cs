using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface ITarget : IEntityType
    {
        public TargetData TargetData { get; }
    }
}