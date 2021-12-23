using System.Collections.Generic;
using DroneBase.Interfaces;
using DroneBase.Models;
using DroneBase.Services;
using DroneBase.Systems;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class GameController : IUpdatable, IFixUpdatable
    {
        private IUpdatable _updateService;
        private IFixUpdatable _fixUpdateService;
        private List<IUnitController> _unitControllers;
        private readonly Camera _camera;
        private PlayerController _playerController;
        private IDroneView _droneView;

        public GameController(Camera camera, IDroneView droneView)
        {
            _camera = camera;
            _droneView = droneView;
        }

        public void StartGame()
        {
            SetupServices();
            
            _playerController = new PlayerController(new MouseInputSystem(_camera), new PlayerModel());
            _unitControllers = new List<IUnitController>
            {
                new DroneController(new DroneModel(3.5f, 120f),
                    _droneView,
                    new NavMeshMovingSystem(_droneView.NavMeshAgent),
                    new NavMeshNavigationSystem())
            };
            
            _playerController.SetSelectedUnit(_unitControllers[0]);
        }

        private void SetupServices()
        {
            var updateService = new UpdateLocalService();
            _updateService = updateService;
            ServiceLocator.SetService(updateService);

            var fixUpdateService = new FixUpdateLocalService();
            _fixUpdateService = fixUpdateService;
            ServiceLocator.SetService(fixUpdateService);
        }

        public void UpdateLocal(float deltaTime)
        {
            _updateService.UpdateLocal(deltaTime);
        }

        public void FixedUpdateLocal()
        {
            _fixUpdateService.FixedUpdateLocal();
        }
    }
}