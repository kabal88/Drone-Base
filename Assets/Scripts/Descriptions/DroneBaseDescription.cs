using System;
using DroneBase.Enums;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions
{
    [Serializable]
    public class DroneBaseDescription : IDroneBaseDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Drone Base Description")] private EntityType _type;
        [SerializeField] private GameObject _prefab;

        public int Id => _identifierContainer.Id;
        public GameObject Prefab => _prefab;
        public IDroneBaseModel BuildingModel => new DroneBaseModel(_type);
    }
}