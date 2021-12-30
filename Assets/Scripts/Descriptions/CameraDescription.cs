using System;
using DroneBase.Data;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public sealed class CameraDescription : ICameraDescription
    {
        [SerializeField, Title("Entity ID")]private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Camera Description")] private GameObject _cameraPrefab;
        [SerializeField, Range(0, 1)] private float _boarderThickness;
        [SerializeField] private Vector2 _moveLimit;
        [SerializeField] private MoveData _moveData;
        [SerializeField] private RotationData _rotationData;
        [SerializeField] private ZoomData _zoomData;

        public int Id => _identifierContainer.Id;
        public GameObject CameraPrefab => _cameraPrefab;

        public ICameraModel CameraModel =>
            new CameraModel(_moveData,
                _rotationData,
                _boarderThickness,
                _moveLimit,
                _zoomData);
    }
}