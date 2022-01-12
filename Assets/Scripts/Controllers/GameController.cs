using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Libraries;
using DroneBase.Services;
using DroneBase.Systems;
using Sirenix.Utilities;

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
            var ui = CanvasController.CreateCanvasController(
                _model.Library.GetCanvasDescription(_model.PresetData.CanvasId), camera.Camera);

            var inputSystem = new InputSystem(camera.Camera);

            camera.InjectMouseInputSystem(inputSystem);

            var drones = CreateDrones(_model.PresetData.DronesPresets);
            var factories = CreateFactories(_model.PresetData.FactoriesPresets);
            var warehouses = CreateWarehouses(_model.PresetData.WarehousesPresetList);
            var droneBases = CreateDroneBases(_model.PresetData.DroneBasesPresetList);

            var units = new List<IUnitController>(drones);
            var buildings = new List<IBuildingController>();
            buildings.AddRange(factories);
            buildings.AddRange(warehouses);
            buildings.AddRange(droneBases);

            var playerController = PlayerController.CreatePlayerController(
                _model.Library.GetPlayerDescription(_model.PresetData.PlayerContainerId),
                inputSystem, ui, units, buildings);
            
            _model.SetIsGameCreated(true);
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

        private List<IDroneController> CreateDrones(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IDroneController>();
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
                        pointModel.PointData, _model.Library.AbilityDescriptions)
                    );
                    pointModel.SetIsBlocked(true);
                }
            }

            return result;
        }

        private List<IFactoryController> CreateFactories(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IFactoryController>();
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

        private List<IWarehouseController> CreateWarehouses(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IWarehouseController>();
            foreach (var preset in presets)
            {
                for (int i = 0; i < preset.Quantity; i++)
                {
                    var pointModel = spawnSystem
                        .GetSpawnPointsByPredicate(x =>
                            x.Model.PointType == EntityType.Building && x.Model.IsBlocked != true).First()
                        .Model;

                    result.Add(WarehouseController.CreateWarehouseController(
                            _model.Library.GetBuildingDescription<IWarehouseDescription, IWarehouseModel>(
                                preset.ContainerId),
                            pointModel.PointData
                        )
                    );

                    pointModel.SetIsBlocked(true);
                }
            }

            return result;
        }
        
        private List<IDroneBaseController> CreateDroneBases(IEnumerable<EntityPresetData> presets)
        {
            var spawnSystem = ServiceLocator.Get<ISpawnSystemService>();
            var result = new List<IDroneBaseController>();
            foreach (var preset in presets)
            {
                for (int i = 0; i < preset.Quantity; i++)
                {
                    var pointModel = spawnSystem
                        .GetSpawnPointsByPredicate(x =>
                            x.Model.PointType == EntityType.Building && x.Model.IsBlocked != true).First()
                        .Model;

                    result.Add(DroneBaseController.CreateDroneBaseController(
                            _model.Library.GetBuildingDescription<IDroneBaseDescription, IDroneBaseModel>(
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
            if (_model.IsGameCreated)
            {
                _model.UpdateService.UpdateLocal(deltaTime);
            }
            
        }

        public void FixedUpdateLocal()
        {
            if (_model.IsGameCreated)
            {
                _model.FixUpdateService.FixedUpdateLocal();
            }
        }
    }
}