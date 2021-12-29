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
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private EntityType _type;
        [SerializeField] private GameObject _factoryPrefab;
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private int _quantity;
        
        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _factoryPrefab;
        public IWarehouseModel BuildingModel => new WarehouseModel(_type, new ResourcesContainer(_quantity,_resourceType));
    }
}