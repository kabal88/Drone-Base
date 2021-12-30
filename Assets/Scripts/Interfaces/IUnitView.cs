namespace DroneBase.Interfaces
{
    public interface IUnitView : IView, INavMeshAgent, ISelectionView, IIdentifier
    {
        void SetID(int id);
    }
}