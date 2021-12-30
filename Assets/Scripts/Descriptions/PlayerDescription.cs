using System;
using System.Collections.Generic;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public sealed class PlayerDescription :IPlayerDescription
    {
        [SerializeField, Title("Entity ID")] private IdentifierContainer _identifierContainer;
        public int Id => _identifierContainer.Id;
        public IPlayerModel PlayerModel => new PlayerModel(new List<IUnitController>());
    }
}