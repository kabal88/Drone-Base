using DroneBase.Interfaces;

namespace DroneBase.Interfaces
{
    public interface IPlayerModel
    {
        ISelectable SelectedObject { get; }

        void SetSelectedObject(ISelectable unit);
    }
}