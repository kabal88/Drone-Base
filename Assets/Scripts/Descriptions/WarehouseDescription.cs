using System;
using System.Collections.Generic;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class WarehouseDescription :IWarehouseDescription
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private EntityType _type;
        [SerializeField] private GameObject _factoryPrefab;
        [SerializeField] private List<ResourcesContainer> _resources;
        
        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _factoryPrefab;
        public IWarehouseModel BuildingModel => new WarehouseModel(_type, _resources);
    }
}