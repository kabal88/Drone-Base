using System;
using System.Collections.Generic;
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
    public class FactoryDescription : IFactoryDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Factory Description")] private EntityType _type;
        [SerializeField] private GameObject _factoryPrefab;
        [SerializeField, TableList] private List<ResourcesContainer> _resources;

        public int Id => _identifierContainer.Id;

        public GameObject Prefab => _factoryPrefab;

        public IFactoryModel BuildingModel => new FactoryModel(_type, _resources);
    }
}