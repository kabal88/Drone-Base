using System;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public abstract class AbilityGenericDescription<T>  : IAbilityDescription where T: IAbility , new()
    {
        public abstract int Id { get; }
        public abstract int QuantityOfCarring { get; }
        public abstract IAbilityModel Model { get; }

        public IAbility GetAbility()
        {
            var ability = new T();
            ability.Init(new AbilityModel(this));
            return ability;
        }

    }
}