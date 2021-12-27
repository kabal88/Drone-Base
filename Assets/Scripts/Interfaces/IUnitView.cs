using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IUnitView:IView, INavMeshAgent, ISelectable, ISelect
    {
        void SetEntityType(EntityType type);
    }
}