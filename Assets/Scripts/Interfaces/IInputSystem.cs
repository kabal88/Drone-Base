using System;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IInputSystem
    {
        public event Action<Vector3> LeftMouseButtonClickPoint;
        public event Action<Vector3> RightMouseButtonClickPoint;
    }
}