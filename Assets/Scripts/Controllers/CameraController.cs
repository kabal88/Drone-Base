using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class CameraController : ICameraController, IUpdatable, IDisposable
    {
        private readonly ICameraView _cameraView;
        private readonly ICameraModel _cameraModel;
        private IMouseInput _mouseInput;

        public ICamera Camera => _cameraView;

        private CameraController(ICameraView cameraView, ICameraModel cameraModel)
        {
            _cameraView = cameraView;
            _cameraModel = cameraModel;
        }

        public static CameraController CreateCameraController(
            ICameraDescription description,
            SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.CameraPrefab, pointData.Position, pointData.Rotation)
                .GetComponent<ICameraView>();
            var model = description.CameraModel;

            model.SetPosition(pointData.Position);
            model.SetRotation(pointData.Rotation);

            var camera = new CameraController(view, model);

            ServiceLocator.Get<UpdateLocalService>().RegisterUpdatable(camera);

            return camera;
        }

        public void InjectMouseInputSystem(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
        }

        public void UpdateLocal(float deltaTime)
        {
            CheckMoveDirection(deltaTime);
        }

        private void CheckMoveDirection(float deltaTime)
        {
            var mousePos = _mouseInput.GetMousePosition();
            if (mousePos.y >= _cameraModel.ScreenHeight * (1 - _cameraModel.BoarderThickness))
            {
                MoveCameraPosition(Direction.Up, deltaTime);
            }

            if (mousePos.y <= _cameraModel.ScreenHeight * _cameraModel.BoarderThickness)
            {
                MoveCameraPosition(Direction.Down, deltaTime);
            }

            if (mousePos.x >= _cameraModel.ScreenWight * (1 - _cameraModel.BoarderThickness))
            {
                MoveCameraPosition(Direction.Right, deltaTime);
            }

            if (mousePos.x <= _cameraModel.ScreenWight * _cameraModel.BoarderThickness)
            {
                MoveCameraPosition(Direction.Left, deltaTime);
            }
        }

        private void MoveCameraPosition(Direction direction, float deltaTime)
        {
            if (direction == Direction.None) return;

            var pos = _cameraModel.Position;
            switch (direction)
            {
                case Direction.Up:
                    pos.z += _cameraModel.Speed * deltaTime;
                    break;
                case Direction.Down:
                    pos.z -= _cameraModel.Speed * deltaTime;
                    break;
                case Direction.Left:
                    pos.x -= _cameraModel.Speed * deltaTime;
                    break;
                case Direction.Right:
                    pos.x += _cameraModel.Speed * deltaTime;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            pos.x = Mathf.Clamp(pos.x, -_cameraModel.MoveLimit.x, _cameraModel.MoveLimit.x);
            pos.z = Mathf.Clamp(pos.z, -_cameraModel.MoveLimit.y, _cameraModel.MoveLimit.y);

            _cameraModel.SetPosition(pos);
            _cameraView.Transform.position = pos;
        }

        public void Dispose()
        {
            ServiceLocator.Get<UpdateLocalService>().UnRegisterUpdatable(this);
        }
    }
}