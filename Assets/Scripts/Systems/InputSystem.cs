using System;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Systems
{
    public class InputSystem: IInputSystem, IUpdatable, IDisposable
    {
        public event Action<Vector3> LeftMouseButtonClickPoint;
        public event Action<Vector3> RightMouseButtonClickPoint;

        private Camera _camera;

        public InputSystem(Camera camera)
        {
            _camera = camera;
            ServiceLocator.Get<UpdateLocalService>().RegisterUpdatable(this);
        }
        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }

        public void UpdateLocal(float deltaTime)
        {
            CheckLeftMouseButton();
            CheckRightMouseButton();
        }

        private void CheckLeftMouseButton()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CustomDebug.Log("LeftMouseButton clicked");
                LeftMouseButtonClickPoint?.Invoke(GetMousePoint());
            }
        }

        private void CheckRightMouseButton()
        {
            if (Input.GetMouseButtonDown(1))
            {
                CustomDebug.Log("RightMouseButton clicked");
                RightMouseButtonClickPoint?.Invoke(GetMousePoint());
            }
        }

        private Vector3 GetMousePoint()
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit);
            return hit.point;
        }

        public void Dispose()
        {
            ServiceLocator.Get<UpdateLocalService>().UnRegisterUpdatable(this);
        }
    }
}