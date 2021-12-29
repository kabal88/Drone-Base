using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public class ResourceGivingAbility : Ability
    {
        public override void Execute(ISelect owner, ITarget target)
        {
            if (owner is IResourceGiver giver)
            {
                if (target is IResourceReceiver receiver)
                {
                    giver.AskForResources(receiver,Model.AmountOfCarring);
                }
            }
        }
    }
}