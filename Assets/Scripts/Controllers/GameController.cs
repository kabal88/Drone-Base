using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Libraries;
using DroneBase.Services;
using DroneBase.Systems;

namespace DroneBase.Controllers
{
    public sealed class GameController : IUpdatable, IFixUpdatable
    {
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
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();

            var camera = CameraController.CreateCameraController(
                _model.Library.GetCameraDescription(_model.PresetData.CameraContainerId),
                spawnSystem.GetSpawnPointsByPredicate(x => x.Model.PointType == EntityType.Camera)
                    .First().Model.PointData);

            var inputSystem = new InputSystem(camera.Camera);

            camera.InjectMouseInputSystem(inputSystem);

            var units = CreateDrones(_model.PresetData.DronesPresetList);
            
            var playerController = PlayerController.CreatePlayerController(
                _model.Library.GetPlayerDescription(_model.PresetData.PlayerContainerId),
                inputSystem, units);
            
            var factory = FactoryController.CreateFactoryController(
                _model.Library.GetBuildingDescription<IFactoryDescription, IFactoryModel>(_model.PresetData
                    .FactoryContainerId),
                spawnSystem.GetSpawnPointsByPredicate(x => x.Model.PointType == EntityType.Building).First().Model
                    .PointData);
        }

        private void SetupServices()
        {
            var updateService = new UpdateLocalService();
            _model.SetUpdateService(updateService);
            ServiceLocator.SetService<IUpdateService>(updateService);

            var fixUpdateService = new FixUpdateLocalService();
            _model.SetFixUpdateService(fixUpdateService);
            ServiceLocator.SetService<IFixUpdateService>(fixUpdateService);

            ServiceLocator.SetService<ISelectionService>(new SelectionService());

            ServiceLocator.SetService<ISpawnSystemService>(SpawnSystemService.CreateSpawnSystem(
                _model.Library.GetSpawnSystemDescription(_model.PresetData.SpawnSystemId)));
        }

        private List<IUnitController> CreateDrones(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IUnitController>();
            foreach (var preset in presets)
            {
                for (int i = 0; i < preset.Quantity; i++)
                {
                    result.Add(
                        DroneController.CreateDroneController(
                            _model.Library.GetUnitDescription<IDroneDescription, IDroneModel>(preset.ContainerId),
                            spawnSystem.GetSpawnPointsByPredicate(x => x.Model.PointType == EntityType.Unit).First()
                                .Model
                                .PointData)
                        );
                }
            }

            return result;
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