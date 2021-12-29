using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using DroneBase.Managers;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Systems
{
    public sealed class InputSystem: IInputSystem, IUpdatable, IDisposable
    {
        public event Action<CustomRaycastHit> LeftMouseButtonClick;
        public event Action<CustomRaycastHit> RightMouseButtonClick;

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
            // if (Input.GetMouseButtonDown(0))
            // {
            //     LeftMouseButtonClick?.Invoke(GetMouseCustomRaycast());
            // }
        }

        private void CheckRightMouseButton()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButtonClick?.Invoke(GetMouseCustomRaycast());
            }
        }

        private CustomRaycastHit GetMouseCustomRaycast()
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit);
            return new CustomRaycastHit(hit);
        }

        public void Dispose()
        {
            ServiceLocator.Get<IUpdateService>().UnRegisterObject(this);
        }
    }
}