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
        private readonly IView _cameraView;
        private readonly ICameraModel _cameraModel;
        private Direction _moveDirection;

        private CameraController(ICameraView cameraView, ICameraModel cameraModel)
        {
            _cameraView = cameraView;
            _cameraModel = cameraModel;
        }

        public static CameraController CreateCameraController(
            ICameraDescription description,
            SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.CameraPrefab, pointData.PointPosition, pointData.Rotation)
                .GetComponent<ICameraView>();
            var camera = new CameraController(view, description.CameraModel);

            ServiceLocator.Get<UpdateLocalService>().RegisterUpdatable(camera);

            return camera;
        }

        public void Move(Direction direction)
        {
            _moveDirection = direction;
        }

        public void UpdateLocal(float deltaTime)
        {
            MoveCameraPosition(deltaTime);
        }

        private void MoveCameraPosition(float deltaTime)
        {
            var pos = _cameraModel.Position;
            switch (_moveDirection)
            {
                case Direction.None:
                    break;
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

            _cameraModel.SetPosition(pos);
            _cameraView.Transform.position = pos;
        }

        public void Dispose()
        {
            ServiceLocator.Get<UpdateLocalService>().UnRegisterUpdatable(this);
        }
    }
}