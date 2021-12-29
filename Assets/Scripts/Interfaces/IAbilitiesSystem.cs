using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IAbilitiesSystem
    {
        public void ExecuteAbility(ISelect owner, DroneAbility index, ITarget target);
    }
}