using System;
using DroneBase.Abilities;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class ResourceCollectingAbilityDescription : AbilityGenericDescription<ResourceCollectingAbility>
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Ability Description")] private int _quantityOfCaring;

        public override int Id => _identifierContainer.Id;
        public override int QuantityOfCarring => _quantityOfCaring;

        public override IAbilityModel Model => new AbilityModel(this);
    }
}