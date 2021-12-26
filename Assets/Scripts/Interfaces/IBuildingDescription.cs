using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IBuildingDescription<out T>: IDescription where T:IBuildingModel
    {
        GameObject Prefab { get; }
        T BuildingModel { get; }
    }
}