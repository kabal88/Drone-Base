﻿using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Data;
using DroneBase.Identifier;
using DroneBase.Interfaces;
using DroneBase.Models;
using UnityEngine;

namespace DroneBase.Descriptions
{
    [Serializable]
    public class SpawnSystemDescription : ISpawnSystemDescription
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        [SerializeField] private List<SpawnPointDescription> _pointDescriptions = new List<SpawnPointDescription>();

        public int Id => _identifierContainer.Id;

        public ISpawnPointModel this[int key]
        {
            get
            {
                foreach (var description in _pointDescriptions.Where(description => description.Id == key))
                {
                    return new SpawnPointModel(description);
                }

                throw new Exception($"drone desc. with id {key} not found");
            }
        }
    }
}