using System.Collections.Generic;
using DroneBase.Interfaces;
using DroneBase.Libraries;
using DroneBase.Services;

namespace DroneBase.Controllers
{
    public class GameController : IUpdatable, IFixUpdatable
    {
        private List<IUnitController> _unitControllers;
        private PlayerController _playerController;
        private readonly IGameModel _model;

        private GameController(IGameModel model)
        {
            _model = model;
        }

        public static GameController CreateGameController(IGameDescription description, Library library)
        {
            var game = new GameController(description.GameModel);
            game._model.Init(library);

            return game;
        }

        public void StartGame()
        {
            SetupServices();
            //var camera = CameraController.CreateCameraController(_model.Library.GetPlayerDescription(_model.PresetData.CameraContainerId))
           // _inputSystem = new InputSystem(_camera);
            // _playerController = PlayerController.CreatePlayerController(
            //     _model.Library.GetPlayerDescription(_model.PresetData.PlayerContainerId),
            //     _inputSystem,
            //     );
                
                // new PlayerController(
                // _inputSystem,
                // new PlayerModel(),
                // new CameraController(new CameraView(), new CameraModel())
                // );

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