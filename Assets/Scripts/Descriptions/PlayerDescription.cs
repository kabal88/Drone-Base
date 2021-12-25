using System;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public sealed class PlayerDescription :IPlayerDescription
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        public int Id => _identifierContainer.Id;
        public IPlayerModel PlayerModel => new PlayerModel();
    }
}