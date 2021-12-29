using System;
using DroneBase.Enums;

namespace DroneBase.Data
{
    [Serializable]
    public readonly struct ResourcesContainer
    {
        public int Quantity { get; }
        public ResourceType Type { get; }

        public ResourcesContainer(int quantity, ResourceType type)
        {
            Quantity = quantity;
            Type = type;
        }
    }
}