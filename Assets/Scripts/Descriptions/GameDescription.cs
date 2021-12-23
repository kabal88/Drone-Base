using System;
using DroneBase.Data;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class GameDescription : IGameDescription
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private GamePresetData _presetData;
        public int Id => _identifierContainer.Id;
        public IGameModel GameModel => new GameModel(_presetData);
    }
}