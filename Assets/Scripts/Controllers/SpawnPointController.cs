﻿using DroneBase.Interfaces;

namespace DroneBase.Controllers
{
    public class SpawnPointController : ISpawnPointController
    {
        public ISpawnPointModel Model { get; }

        private ISpawnPointView _view;

        public SpawnPointController(ISpawnPointModel model, ISpawnPointView view)
        {
            Model = model;
            _view = view;
        }
    }
}