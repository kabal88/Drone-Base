using System;
using DroneBase.Abilities;
using DroneBase.Descriptions;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Descriptions
{
    [Serializable]
    public class ResourceGivingAbilityDescription : AbilityGenericDescription<ResourceGivingAbility>
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Ability Description")] private int _quantityOfCaring;

        public override int Id => _identifierContainer.Id;
        public override int QuantityOfCarring => _quantityOfCaring;

        public override IAbilityModel Model => new AbilityModel(this);
    }
}