using System;
using DroneBase.Identifier;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct GamePresetData
    {
       [SerializeField] private IdentifierContainer _playerIdentifierContainer;
       [SerializeField] private IdentifierContainer _droneIdentifierContainer;
       [SerializeField] private IdentifierContainer _cameraIdentifierContainer;
       [SerializeField] private IdentifierContainer _spawnSystemIdentifierContainer;

       public int PlayerContainerId => _playerIdentifierContainer.Id;
       public int DroneContainerId => _droneIdentifierContainer.Id;
       public int CameraContainerId => _cameraIdentifierContainer.Id;
       public int SpawnSystemId => _spawnSystemIdentifierContainer.Id;
    }
}