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
    public class Library
    {
        [SerializeField] private List<Description> Descriptions = new List<Description>();

        private Dictionary<int, IDroneDescription> _droneDescriptions = new Dictionary<int, IDroneDescription>();
        private Dictionary<int, IPlayerDescription> _playerDescriptions = new Dictionary<int, IPlayerDescription>();
        private Dictionary<int, ICameraDescription> _cameraDescriptions = new Dictionary<int, ICameraDescription>();
        private Dictionary<int, IGameDescription> _gameDescriptions = new Dictionary<int, IGameDescription>();
        private Dictionary<int, ISpawnSystemDescription> _spawnSystemDescriptions = new Dictionary<int, ISpawnSystemDescription>();

        public void Init()
        {
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is IDroneDescription data )
                {
                    _droneDescriptions.Add(description.GetDescription.Id,data);
                }
            }
            
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is IPlayerDescription data )
                {
                    _playerDescriptions.Add(description.GetDescription.Id,data);
                }
            }
            
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is ICameraDescription data )
                {
                    _cameraDescriptions.Add(description.GetDescription.Id,data);
                }
            }
            
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is IGameDescription data )
                {
                    _gameDescriptions.Add(description.GetDescription.Id,data);
                }
            }

            foreach (var description in Descriptions)
            {
                if (description.GetDescription is ISpawnSystemDescription data)
                {
                    _spawnSystemDescriptions.Add(description.GetDescription.Id,data);
                }
            }
            
        }

        public void LoadAllAssets()
        {
            Descriptions = AssetDatabase.FindAssets("t:Description")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<Description>).ToList();
        }

        public IDroneDescription GetDroneDescription(int id)
        {
            if (_droneDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
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
    }
}