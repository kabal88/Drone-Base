using System.Collections.Generic;
using DroneBase.Enums;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitDescription<out T>: IDescription where T: IUnitModel
    {
        GameObject Prefab { get; }
        T Model { get; }
        Dictionary<DroneAbility,int> AvailableAbilitiesMap { get; }
    }
}