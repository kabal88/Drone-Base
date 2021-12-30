using System;
using DroneBase.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable, HideLabel]
    public struct ResourcesContainer
    {
        [SerializeField, TableColumnWidth(200)] private ResourceType _type;
        [SerializeField, TableColumnWidth(60)] private int _quantity;
        public int Quantity => _quantity;
        public ResourceType Type => _type;

        public ResourcesContainer(int quantity, ResourceType type)
        {
            _quantity = quantity;
            _type = type;
        }
    }
}