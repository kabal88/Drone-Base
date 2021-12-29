using System.Collections.Generic;
using DroneBase.Data;
using UnityEngine;
using DroneBase.Enums;
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class FactoryModel :IFactoryModel
    {
        private Dictionary<ResourceType, int> _resourceStorage;
        public EntityType Type { get; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public Vector3 InteractivePoint { get; private set; }

        public TargetData GetTargetData => new TargetData(InteractivePoint, Type);

        public FactoryModel(EntityType type, List<ResourcesContainer> resources, Vector3 interactivePoint = default, Vector3 position = default, Quaternion rotation = default)
        {
            _resourceStorage = new Dictionary<ResourceType, int>();

            foreach (var resource in resources)
            {
                AddResource(resource);
            }

            
            Type = type;
            InteractivePoint = interactivePoint;
            Position = position;
            Rotation = rotation;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }

        public void SetInteractivePoint(Vector3 point)
        {
            InteractivePoint = point;
        }
        
        public void AddResource(ResourcesContainer container)
        {
            if (_resourceStorage.ContainsKey(container.Type))
            {
                _resourceStorage[container.Type] += container.Quantity;
            }
            else
            {
                _resourceStorage.Add(container.Type,container.Quantity);
            }
        }

        public bool TryGetResource(ResourcesContainer container, out int qty)
        {
            var result = false;
            qty = 0;
            if (_resourceStorage.TryGetValue(container.Type, out var storageQuantity))
            {
                if (storageQuantity >= container.Quantity)
                {
                    storageQuantity -= container.Quantity;
                    qty = container.Quantity;
                    result = true;
                }
                else if (storageQuantity >= 0)
                {
                    qty = storageQuantity;
                    storageQuantity = 0;
                }
            }

            return result;
        }

        public bool TryGetQuantityOfResource(ResourceType type, out int qty)
        {
            return _resourceStorage.TryGetValue(type, out qty);
        }
    }
}