using System;
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

        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _dronePrefab;
        public IDroneModel Model => new DroneModel(_moveData, _rotationData, _type);
    }
}