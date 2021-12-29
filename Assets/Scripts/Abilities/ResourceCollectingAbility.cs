using System;
using DroneBase.Interfaces;

namespace DroneBase.Abilities
{
    public class ResourceCollectingAbility : Ability
    {
        public override void Execute(ISelect owner, ITarget target)
        {
            if (owner is IResourceReceiver receiver)
            {
                if (target is IResourceGiver giver)
                {
                    giver.AskForResources(receiver,Model.AmountOfCarring);
                }
            }
        }
    }
}