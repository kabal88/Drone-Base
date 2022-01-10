using System;
using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public class ResourceCollectingAbility : Ability
    {
        public override void Execute(ISelect owner, ITarget target)
        {
            if (!(owner is IResourceReceiver receiver)) return;
            if (!(target is IResourceProvider giver)) return;
            
            var resources = giver.GetResources(Model.AmountOfCarring);
            receiver.TakeResources(resources);
        }
    }
}