namespace DroneBase.Interfaces
{
    public interface ISelect : IEntityType
    {
        void SetSelection();
        void ClearSelection();
    }
}