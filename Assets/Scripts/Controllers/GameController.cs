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

            var units = CreateDrones(_model.PresetData.UnitsPresets);

            var playerController = PlayerController.CreatePlayerController(
                _model.Library.GetPlayerDescription(_model.PresetData.PlayerContainerId),
                inputSystem, units);

            var factories = CreateBuildings(_model.PresetData.BuildingsPresets);
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
                    var pointModel = spawnSystem.GetSpawnPointsByPredicate(x =>
                            x.Model.PointType == EntityType.Unit && x.Model.IsBlocked != true)
                        .First()
                        .Model;
                    result.Add(DroneController.CreateDroneController(
                        _model.Library.GetUnitDescription<IDroneDescription, IDroneModel>(preset.ContainerId),
                        pointModel.PointData)
                    );
                    pointModel.SetIsBlocked(true);
                }
            }

            return result;
        }

        private List<IBuildingController> CreateBuildings(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IBuildingController>();
            foreach (var preset in presets)
            {
                for (int i = 0; i < preset.Quantity; i++)
                {
                    var pointModel = spawnSystem
                        .GetSpawnPointsByPredicate(x =>
                            x.Model.PointType == EntityType.Building && x.Model.IsBlocked != true).First()
                        .Model;

                    result.Add(FactoryController.CreateFactoryController(
                            _model.Library.GetBuildingDescription<IFactoryDescription, IFactoryModel>(
                                preset.ContainerId),
                            pointModel.PointData
                        )
                    );
                    
                    pointModel.SetIsBlocked(true);
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