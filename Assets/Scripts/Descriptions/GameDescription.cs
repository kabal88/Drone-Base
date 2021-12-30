using System;
using DroneBase.Data;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public sealed class GameDescription : IGameDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        [SerializeField, Title("Presets")] private GamePresetData _presetData;
        public int Id => _identifierContainer.Id;
        public IGameModel GameModel => new GameModel(_presetData);
    }
}