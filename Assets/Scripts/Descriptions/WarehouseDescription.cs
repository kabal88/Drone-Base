using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Descriptions
{
    public class WarehouseDescription :IWarehouseDescription
    {
        public int Id { get; }
        public GameObject Prefab { get; }
        public IFactoryModel BuildingModel { get; }
    }
}