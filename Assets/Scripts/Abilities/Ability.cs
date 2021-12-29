using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public abstract class Ability: IAbility
    {
        protected IAbilityModel Model;
        
        public void Init(IAbilityModel model)
        {
            Model = model;
        }

        public abstract void Execute(ISelect owner, ITarget target);
    }
}