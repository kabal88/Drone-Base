using System;
using DroneBase.Enums;
using DroneBase.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct SpawnPointDescription
    {
        [SerializeField, TableColumnWidth(200)] private IdentifierContainer _identifierContainer;
        [TableColumnWidth(60)] public EntityType PointType;
        public bool IsBlocked;
        [HideInInspector] public SpawnPointData PointData;

        public int Id => _identifierContainer.Id;
    }
}