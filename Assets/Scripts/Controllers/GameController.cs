using System.Collections.Generic;
using DroneBase.Interfaces;
using DroneBase.Libraries;
using DroneBase.Models;
using DroneBase.Services;
using DroneBase.Systems;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class GameController : IUpdatable, IFixUpdatable
    {
        private List<IUnitController> _unitControllers;
        private readonly Camera _camera;
        private PlayerController _playerController;
        private IDroneView _droneView;
        private IInputSystem _inputSystem;
        private GameModel _model;

        public GameController(GameModel model)
        {
            _model = model;
        }

        public void StartGame()
        {
            SetupServices();
            _inputSystem = new InputSystem(_camera);
            _playerController = new PlayerController(
                _inputSystem,
                new PlayerModel(),
                new CameraController(new CameraView(), new CameraModel())
                );

            _playerController.SetSelectedUnit(_unitControllers[0]);
        }

        private void SetupServices()
        {
            var updateService = new UpdateLocalService();
            _model.SetUpdateService(updateService);
            ServiceLocator.SetService(updateService);

            var fixUpdateService = new FixUpdateLocalService();
            _model.SetFixUpdateService(fixUpdateService);
            ServiceLocator.SetService(fixUpdateService);
        }

        public void UpdateLocal(float deltaTime)
        {
            _model.UpdateService.UpdateLocal(deltaTime);
        }

        public void FixedUpdateLocal()
        {
            _model.FixUpdateService.FixedUpdateLocal();
        }
    }
}