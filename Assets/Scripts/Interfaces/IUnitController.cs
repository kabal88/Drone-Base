using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IUnitController: IAimable, ISelectable, ISelect, IUnitContext, IIdentifier
    {
        public TargetData PreviousTarget { get; }
        void SetState(IUnitState state);
        void PreviousState();
    }
}