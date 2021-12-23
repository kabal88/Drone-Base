using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class PlayerModel : IPlayerModel
    {
        public IUnitController SelectedUnit { get; private set; }

        public void SetSelectedUnit(IUnitController unit)
        {
            SelectedUnit = unit;
        }
    }
}