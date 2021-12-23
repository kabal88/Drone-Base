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
    public class Library
    {
        [SerializeField] private List<Description> Descriptions = new List<Description>();

        private Dictionary<int, DroneDescription> _droneDescriptions = new Dictionary<int, DroneDescription>();
        private Dictionary<int, PlayerDescription> _playerDescriptions = new Dictionary<int, PlayerDescription>();
        private Dictionary<int, CameraDescription> _cameraDescriptions = new Dictionary<int, CameraDescription>();


        public void Init()
        {
            foreach (var description in Descriptions)
            {
                if (description.GetDescription is DroneDescription data )
                {
                    _droneDescriptions.Add(description.GetDescription.Id,data);
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
        
            throw new Exception($"drone with id {id} not found");
        }

        public IPlayerDescription GetPlayerDescription(int id)
        {
            if (_playerDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }
        
            throw new Exception($"player with id {id} not found");
        }

        public ICameraDescription GetCameraDescription(int id)
        {
            if (_cameraDescriptions.TryGetValue(id, out var needed))
            {
                return needed;
            }

            throw new Exception($"camera with id {id} not found");
        }
    }
}