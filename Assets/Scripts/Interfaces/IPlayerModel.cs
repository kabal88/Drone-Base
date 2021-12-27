using System.Collections.Generic;

namespace DroneBase.Interfaces
{
    public interface IPlayerModel
    {
        ISelect SelectedObject { get; }
        IEnumerable<IUnitController> AllUnits { get; }

        void SetSelectedObject(ISelect unit);
        void AddUnit(IUnitController unit);
        void RemoveUnit(IUnitController unit);
    }
}