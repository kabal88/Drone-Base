using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IUnitDescription<out T>: IDescription where T: IUnitModel
    {
        GameObject Prefab { get; }
        T Model { get; }
    }
}