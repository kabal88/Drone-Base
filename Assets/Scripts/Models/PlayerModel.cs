using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public sealed class PlayerModel : IPlayerModel
    {
        public ISelectable SelectedObject { get; private set; }

        public void SetSelectedObject(ISelectable unit)
        {
            SelectedObject = unit;
        }
    }
}