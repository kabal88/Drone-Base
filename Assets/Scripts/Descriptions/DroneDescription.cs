using System;
using DroneBase.Data;
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
        [SerializeField] private GameObject _dronePrefab;
        [SerializeField] private MoveData _moveData;
        [SerializeField] private RotationData _rotationData;

        public int Id => _identifierContainer.Id;
        public GameObject DronePrefab => _dronePrefab;
        public IDroneModel DroneModel => new DroneModel(_moveData, _rotationData);
    }
}