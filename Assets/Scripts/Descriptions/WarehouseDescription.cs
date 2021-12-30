using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class WarehouseDescription :IWarehouseDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("WarehouseDescription")] private EntityType _type;
        [SerializeField] private GameObject _factoryPrefab;
        [SerializeField,BoxGroup("Resource Storage")] private ResourcesContainer _resourceStorage;

        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _factoryPrefab;
        public IWarehouseModel BuildingModel => new WarehouseModel(_type, _resourceStorage);
    }
}