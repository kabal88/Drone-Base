using System;
using System.Collections.Generic;
using DroneBase.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Data
{
    [Serializable,HideLabel]
    public struct GamePresetData
    {
       [SerializeField, Title("Player",Bold = false)] private IdentifierContainer _playerIdentifierContainer;
       [SerializeField, Title("Scene components",Bold = false)] private IdentifierContainer _cameraIdentifierContainer;
       [SerializeField] private IdentifierContainer _spawnSystemIdentifierContainer;
       [Title("Buildings",Bold = false)]
       [SerializeField, TableList] private List<EntityPresetData> _factoriesPresetList;
       [SerializeField, TableList] private List<EntityPresetData> _warehousesPresetList;
       [SerializeField, TableList] private List<EntityPresetData> _droneBasesPresetList;
       [Title("Units",Bold = false)]
       [SerializeField, TableList] private List<EntityPresetData> _dronesPresetList;

       public int PlayerContainerId => _playerIdentifierContainer.Id;
       public int CameraContainerId => _cameraIdentifierContainer.Id;
       public int SpawnSystemId => _spawnSystemIdentifierContainer.Id;

       public IEnumerable<EntityPresetData> DronesPresets => _dronesPresetList;
       public IEnumerable<EntityPresetData> FactoriesPresets => _factoriesPresetList;
       public IEnumerable<EntityPresetData> WarehousesPresetList => _warehousesPresetList;
       public IEnumerable<EntityPresetData> DroneBasesPresetList => _droneBasesPresetList;
    }
}