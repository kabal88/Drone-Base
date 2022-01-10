using System;
using System.Collections.Generic;
using System.Linq;
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

        private Dictionary<int, IAbilityDescription> _abilityDescriptions = new Dictionary<int, IAbilityDescription>();

        private Dictionary<int, ICanvasDescription> _canvasDescriptions = new Dictionary<int, ICanvasDescription>();

        public void Init()
        {
            foreach (var description in Descriptions)
            {
                switch (description.GetDescription)
                {
                    case IUnitDescription<IUnitModel> data:
                        _unitDescriptions.Add(description.GetDescription.Id, data);
                        break;
                    case IPlayerDescription player:
                        _playerDescriptions.Add(description.GetDescription.Id, player);
                        break;
                    case ICameraDescription camera:
                        _cameraDescriptions.Add(description.GetDescription.Id, camera);
                        break;
                    case IGameDescription game:
                        _gameDescriptions.Add(description.GetDescription.Id, game);
                        break;
                    case ISpawnSystemDescription spawn:
                        _spawnSystemDescriptions.Add(description.GetDescription.Id, spawn);
                        break;
                    case IBuildingDescription<IBuildingModel> building:
                        _buildingDescriptions.Add(description.GetDescription.Id, building);
                        break;
                    case IAbilityDescription ability:
                        _abilityDescriptions.Add(description.GetDescription.Id,ability);
                        break;
                    case ICanvasDescription canvas:
                        _canvasDescriptions.Add(description.GetDescription.Id,canvas);
                        break;
                }
            }
        }

        public void LoadAllAssets()
        {
            Descriptions = AssetDatabase.FindAssets("t:Description")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<Description>).ToList();
        }

        public TDescription GetUnitDescription<TDescription, TModel>(int id) where TDescription : IUnitDescription<TModel> where TModel : IUnitModel
        {
            if (_unitDescriptions.TryGetValue(id, out var needed))
            {
                return (TDescription)needed;
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

        public TDescription GetBuildingDescription<TDescription, TModel>(int id) where TDescription : IBuildingDescription<TModel> where TModel : IBuildingModel
        {
            if (_buildingDescriptions.TryGetValue(id, out var needed))
            {
                return (TDescription)needed;
            }

            throw new Exception($"Building desc. with id {id} not found");
        }

        public IAbilityDescription GetAbilityDescription(int id)
        {
            if (_abilityDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"Ability desc. with id {id} not found");
        }

        public ICanvasDescription GetCanvasDescription(int id)
        {
            if (_canvasDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"Canvas desc. with id {id} not found");
        }
    }
}