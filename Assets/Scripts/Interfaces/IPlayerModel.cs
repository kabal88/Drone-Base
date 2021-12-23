using DroneBase.Interfaces;

namespace DroneBase.Interfaces
{
    public interface IPlayerModel
    {
        IUnitController SelectedUnit { get; }

        void SetSelectedUnit(IUnitController unit);
    }
}