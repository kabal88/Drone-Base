using System.Collections.Generic;
using System.Linq;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public sealed class PlayerModel : IPlayerModel
    {

        private List<IUnitController> _unitControllers;
        private List<IDroneController> _droneControllers;
        public bool IsAlarmOn { get; private set;}
        public ISelect SelectedObject { get; private set; }
        public IEnumerable<IUnitController> AllUnits => _unitControllers;
        public IEnumerable<IDroneController> AllDrones => _droneControllers;

        public PlayerModel(List<IUnitController> allUnits)
        {
            _unitControllers = allUnits;
            _droneControllers = new List<IDroneController>();
        }

        public void SetIsAlarmOn(bool isOn)
        {
            IsAlarmOn = isOn;
        }

        public void SetSelectedObject(ISelect unit)
        {
            SelectedObject = unit;
        }

        public void AddUnit(IUnitController unit)
        {
            _unitControllers.Add(unit);
            
            if (unit is IDroneController drone)
            {
                _droneControllers.Add(drone);
            }
        }

        public void RemoveUnit(IUnitController unit)
        {
            _unitControllers.Remove(unit);
            
            if (unit is IDroneController drone)
            {
                _droneControllers.Remove(drone);
            }
        }
    }
}