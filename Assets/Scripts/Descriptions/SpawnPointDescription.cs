using System;
using DroneBase.Enums;
using DroneBase.Identifier;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct SpawnPointDescription
    {
       [SerializeField] private IdentifierContainer _identifierContainer;
       
        public EntityType PointType;
        public bool IsBlocked;
        public SpawnPointData PointData;

        public int Id => _identifierContainer.Id;
    }
}