using System;
using DroneBase.Interfaces;
using DroneBase.Managers;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Systems
{
    public sealed class InputSystem: IInputSystem, IUpdatable, IDisposable
    {
        public event Action<Vector3> LeftMouseButtonClickPoint;
        public event Action<Vector3> RightMouseButtonClickPoint;

        private Camera _camera;

        public InputSystem(ICamera camera)
        {
            _camera = camera.Camera;
            ServiceLocator.Get<IUpdateService>().RegisterObject(this);
        }

        public float Scroll => Input.GetAxis(TagManager.MOUSE_SCROLLWHEEL);

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
                LeftMouseButtonClickPoint?.Invoke(GetMouseRaycastPoint());
            }
        }

        private void CheckRightMouseButton()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButtonClickPoint?.Invoke(GetMouseRaycastPoint());
            }
        }

        private Vector3 GetMouseRaycastPoint()
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit);
            return hit.point;
        }

        public void Dispose()
        {
            ServiceLocator.Get<IUpdateService>().UnRegisterObject(this);
        }
    }
}