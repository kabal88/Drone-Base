using System;
using DroneBase.Enums;
using DroneBase.Identifier;
using Sirenix.OdinInspector;

namespace DroneBase.Data
{
    [Serializable]
    public struct AbilityData
    {
        [TableColumnWidth(200)] public IdentifierContainer IdentifierContainer;
        [TableColumnWidth(60)] public DroneAbility Ability;
    }
}