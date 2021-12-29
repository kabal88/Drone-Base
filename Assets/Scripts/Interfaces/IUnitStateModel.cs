using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IUnitStateModel
    {
        public TargetData GetTargetData { get; }
        void SetTarget(TargetData data);
    }
}