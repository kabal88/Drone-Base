using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public class ResourceGivingAbility : Ability
    {
        public override void Execute(ISelect owner, ITarget target)
        {
            if (!(owner is IResourceProvider giver)) return;
            if (!(target is IResourceReceiver receiver)) return;
            
            CustomDebug.Log($"ResourceGivingAbility - Execute");
            
            var resources = giver.GetResources(Model.AmountOfCarring);
            receiver.TakeResources(resources);
        }
    }
}