using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public abstract class Ability: IAbility
    {
        public abstract void Execute(ISelect owner, ITarget target);
    }
}