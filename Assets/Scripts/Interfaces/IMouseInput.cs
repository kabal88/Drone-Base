using System;
using DroneBase.Data;
using UnityEngine;


namespace DroneBase.Interfaces
{
    public interface IMouseInput
    {
        public event Action<CustomRaycastHit> LeftMouseButtonClick;
        public event Action<CustomRaycastHit> RightMouseButtonClick;

        float Scroll { get; }
        Vector3 GetMousePosition();
    }
}