using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IBuildingView: IView, ISelectable, ITargetable, ISelect, ITarget
    {
        void SetEntityType(EntityType type);
        void SetTarget(ITarget target);
    }
}