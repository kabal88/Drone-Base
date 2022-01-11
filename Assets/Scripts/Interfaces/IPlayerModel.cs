using System.Collections.Generic;

namespace DroneBase.Interfaces
{
    public interface IPlayerModel
    {
        bool IsAlarmOn { get; }
        ISelect SelectedObject { get; }
        IEnumerable<IUnitController> AllUnits { get; }
        IEnumerable<IDroneController> AllDrones { get; }
        IEnumerable<IBuildingController> AllBuildings { get; }
        IEnumerable<IDroneBaseController> AllDroneBase { get; }

        void SetIsAlarmOn(bool isOn);
        void SetSelectedObject(ISelect unit);
        void AddUnit(IUnitController unit);
        void RemoveUnit(IUnitController unit);
        void AddBuilding(IBuildingController building);
        void RemoveBuilding(IBuildingController building);
    }
}