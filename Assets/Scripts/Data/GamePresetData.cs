using System;
using System.Collections.Generic;
using DroneBase.Identifier;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable]
    public struct GamePresetData
    {
       [SerializeField] private IdentifierContainer _playerIdentifierContainer;
       [SerializeField] private IdentifierContainer _cameraIdentifierContainer;
       [SerializeField] private IdentifierContainer _spawnSystemIdentifierContainer;
       [SerializeField] private List<EntityPresetData> _buildingsPresetList;
       [SerializeField] private List<EntityPresetData> _unitsPresetList;

       public int PlayerContainerId => _playerIdentifierContainer.Id;
       public int CameraContainerId => _cameraIdentifierContainer.Id;
       public int SpawnSystemId => _spawnSystemIdentifierContainer.Id;

       public IEnumerable<EntityPresetData> UnitsPresets => _unitsPresetList;
       public IEnumerable<EntityPresetData> BuildingsPresets => _buildingsPresetList;
    }
}