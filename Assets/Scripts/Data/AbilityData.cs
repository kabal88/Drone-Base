using System;
using DroneBase.Enums;
using DroneBase.Identifier;

namespace DroneBase.Data
{
    [Serializable]
    public struct AbilityData
    {
        public DroneAbility Ability;
        public IdentifierContainer IdentifierContainer;
    }
}