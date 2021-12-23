using System;
using DroneBase.Data;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class CameraDescription : ICameraDescription
    {
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private MoveData _moveData;
        [SerializeField] private RotationData _rotationData;
        
        public int Id => _identifierContainer.Id;
        public GameObject CameraPrefab => _cameraPrefab;
        public ICameraModel CameraModel => new CameraModel(_moveData, _rotationData);
    }
}