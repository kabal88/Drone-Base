using System;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IDroneView : IUnitView
    {
        public event Action<Collider> SensorEnterTrigger;
        public event Action<Collider> SensorExitTrigger;

        void SetAnimationVelocity(float velocity);
        void SetResourceVisibility(bool isVisible);
    }
}