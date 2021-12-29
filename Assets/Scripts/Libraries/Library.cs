using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Controllers;
using DroneBase.Descriptions;
using DroneBase.Interfaces;
using UnityEditor;
using UnityEngine;

namespace DroneBase.Libraries
{
    [Serializable]
    public sealed class Library
    {
        [SerializeField] private List<Description> Descriptions = new List<Description>();

        private Dictionary<int, IUnitDescription<IUnitModel>> _unitDescriptions =
            new Dictionary<int, IUnitDescription<IUnitModel>>();

        private Dictionary<int, IPlayerDescription> _playerDescriptions = new Dictionary<int, IPlayerDescription>();
        private Dictionary<int, ICameraDescription> _cameraDescriptions = new Dictionary<int, ICameraDescription>();
        private Dictionary<int, IGameDescription> _gameDescriptions = new Dictionary<int, IGameDescription>();

        private Dictionary<int, ISpawnSystemDescription> _spawnSystemDescriptions =
            new Dictionary<int, ISpawnSystemDescription>();

        private Dictionary<int, IBuildingDescription<IBuildingModel>> _buildingDescriptions =
            new Dictionary<int, IBuildingDescription<IBuildingModel>>();

        public void Init()
        {
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is IUnitDescription<IUnitModel> data)
                    _unitDescriptions.Add(description.GetDescription.Id, data);
                else if (description.GetDescription is IPlayerDescription player)
                    _playerDescriptions.Add(description.GetDescription.Id, player);
                else if (description.GetDescription is ICameraDescription camera)
                    _cameraDescriptions.Add(description.GetDescription.Id, camera);
                else if (description.GetDescription is IGameDescription game)
                    _gameDescriptions.Add(description.GetDescription.Id, game);
                else if (description.GetDescription is ISpawnSystemDescription spawn)
                    _spawnSystemDescriptions.Add(description.GetDescription.Id, spawn);
                else if (description.GetDescription is IBuildingDescription<IBuildingModel> building)
                    _buildingDescriptions.Add(description.GetDescription.Id, building);
            }
        }

        public void LoadAllAssets()
        {
            Descriptions = AssetDatabase.FindAssets("t:Description")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<Description>).ToList();
        }

        public T GetUnitDescription<T, TM>(int id) where T : IUnitDescription<TM> where TM : IUnitModel
        {
            if (_unitDescriptions.TryGetValue(id, out var needed))
            {
                return (T)needed;
            }

            throw new Exception($"drone desc. with id {id} not found");
        }

        public IPlayerDescription GetPlayerDescription(int id)
        {
            if (_playerDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"player desc. with id {id} not found");
        }

        public ICameraDescription GetCameraDescription(int id)
        {
            if (_cameraDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"camera desc. with id {id} not found");
        }

        public IGameDescription GetGameDescription(int id)
        {
            if (_gameDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"game desc. with id {id} not found");
        }

        public ISpawnSystemDescription GetSpawnSystemDescription(int id)
        {
            if (_spawnSystemDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"SpawnSystem desc. with id {id} not found");
        }

        public T GetBuildingDescription<T, TM>(int id) where T : IBuildingDescription<TM> where TM : IBuildingModel
        {
            if (_buildingDescriptions.TryGetValue(id, out var needed))
            {
                return (T)needed;
            }

            throw new Exception($"Building desc. with id {id} not found");
        }
    }
}