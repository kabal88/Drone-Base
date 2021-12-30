using System;
using DroneBase.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct EntityPresetData
    {
        [SerializeField, TableColumnWidth(200)] private IdentifierContainer _identifierContainer;
        [SerializeField] private int _quantity;

        public int ContainerId => _identifierContainer.Id;
        public int Quantity => _quantity;
    }
}