using System;
using DroneBase.Abilities;
using DroneBase.Descriptions;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace Scripts.Descriptions
{
    [Serializable]
    public class ResourceGivingAbilityDescription : AbilityGenericDescription<ResourceGivingAbility>
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private int _quantityOfCaring;

        public override int Id => _identifierContainer.Id;
        public override int QuantityOfCarring => _quantityOfCaring;

        public override IAbilityModel Model => new AbilityModel(this);
    }
}