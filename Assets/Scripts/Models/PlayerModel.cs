using System.Collections.Generic;
using System.Linq;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public sealed class PlayerModel : IPlayerModel
    {

        private List<IUnitController> _unitControllers;
        private List<IDroneController> _droneControllers;
        private List<IBuildingController> _buildingControllers;
        private List<IDroneBaseController> _baseControllers;
        public bool IsAlarmOn { get; private set;}
        public ISelect SelectedObject { get; private set; }
        public IEnumerable<IUnitController> AllUnits => _unitControllers;
        public IEnumerable<IDroneController> AllDrones => _droneControllers;
        public IEnumerable<IBuildingController> AllBuildings => _buildingControllers;
        public IEnumerable<IDroneBaseController> AllDroneBase => _baseControllers;

        
        public PlayerModel(List<IUnitController> allUnits = default, List<IBuildingController> buildingControllers = default)
        {
            _unitControllers = allUnits;
            _buildingControllers = buildingControllers;
            _baseControllers = new List<IDroneBaseController>();
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

        public void AddBuilding(IBuildingController building)
        {
            _buildingControllers.Add(building);
            
            if (building is IDroneBaseController dBase)
            {
                _baseControllers.Add(dBase);
            }
        }

        public void RemoveBuilding(IBuildingController building)
        {
            _buildingControllers.Remove(building);
            
            if (building is IDroneBaseController dBase)
            {
                _baseControllers.Remove(dBase);
            }
        }
    }
}