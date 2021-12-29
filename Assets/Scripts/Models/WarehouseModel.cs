using System.Collections.Generic;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public class WarehouseModel : IWarehouseModel
    {
        public EntityType Type { get; }
        public Vector3 InteractivePoint { get; private set; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public TargetData GetTargetData => new TargetData(InteractivePoint, Type);
        public ResourceType StorageResourceType { get; }
        public int StorageResourceQuantity { get; private set; }

        public WarehouseModel(EntityType type, ResourcesContainer resources, Vector3 interactivePoint = default,
            Vector3 position = default, Quaternion rotation = default)
        {
            StorageResourceType = resources.Type;
            StorageResourceQuantity = resources.Quantity;
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
            if (StorageResourceType == container.Type)
            {
                StorageResourceQuantity += container.Quantity;
            }
        }

        public bool TryGetResource(ResourcesContainer container, out int qty)
        {
            var result = false;
            qty = 0;

            if (StorageResourceType == container.Type)
            {
                if (StorageResourceQuantity >= container.Quantity)
                {
                    StorageResourceQuantity -= container.Quantity;
                    qty = container.Quantity;
                    result = true;
                }
                else if (StorageResourceQuantity >= 0)
                {
                    qty = StorageResourceQuantity;
                    StorageResourceQuantity = 0;
                }
            }

            return result;
        }


        public bool TryGetQuantityOfResource(ResourceType type, out int qty)
        {
            var result = false;
            qty = 0;
            if (StorageResourceType == type)
            {
                qty = StorageResourceQuantity;
                result = true;
            }

            return result;
        }
    }
}