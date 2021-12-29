using System;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IDroneView : IUnitView
    {
        public event Action<Collider> SensorCollide;
    }
}