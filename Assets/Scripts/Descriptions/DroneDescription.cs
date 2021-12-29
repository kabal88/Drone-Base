using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public sealed class DroneDescription : IDroneDescription
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private EntityType _type;
        [SerializeField] private GameObject _dronePrefab;
        [SerializeField] private MoveData _moveData;
        [SerializeField] private RotationData _rotationData;
        [SerializeField] private List<AbilityData> _availableAbilitiesData; 
        
        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _dronePrefab;
        public IDroneModel Model => new DroneModel(_moveData, _rotationData, _type);

        public Dictionary<DroneAbility, int> AvailableAbilitiesMap =>
            _availableAbilitiesData.ToDictionary(data => data.Ability, data => data.IdentifierContainer.Id);
    }
}