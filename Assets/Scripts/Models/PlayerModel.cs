using System.Collections.Generic;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public sealed class PlayerModel : IPlayerModel
    {

        private List<IUnitController> _unitControllers;
        public ISelect SelectedObject { get; private set; }
        public IEnumerable<IUnitController> AllUnits => _unitControllers;

        public PlayerModel(List<IUnitController> allUnits)
        {
            _unitControllers = allUnits;
        }

        public void SetSelectedObject(ISelect unit)
        {
            SelectedObject = unit;
        }

        public void AddUnit(IUnitController unit)
        {
            _unitControllers.Add(unit);
        }

        public void RemoveUnit(IUnitController unit)
        {
            _unitControllers.Remove(unit);
        }
    }
}