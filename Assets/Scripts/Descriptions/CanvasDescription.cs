using System;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions
{
    [Serializable]
    public class CanvasDescription : ICanvasDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Canvas Description")] private GameObject _prefab;
        [SerializeField] private bool _isAlarmOn;
        [SerializeField] private float _planeDistance;

        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _prefab;
        public ICanvasModel Model => new CanvasModel(_isAlarmOn, _planeDistance);
    }
}