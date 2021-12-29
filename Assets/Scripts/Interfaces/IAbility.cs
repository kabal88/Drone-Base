using UnityEngine.PlayerLoop;

namespace DroneBase.Interfaces
{
    public interface IAbility
    {
        void Init(IAbilityModel model);
        void Execute(ISelect owner, ITarget target);
    }
}