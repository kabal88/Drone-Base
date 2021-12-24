using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Controllers;
using DroneBase.Data;
using DroneBase.Interfaces;
using DroneBase.Managers;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase.Systems
{
    public class SpawnSystem : ISpawnSystem
    {
        private List<ISpawnPointController> _pointControllers;

        private SpawnSystem(List<ISpawnPointController> pointControllers)
        {
            _pointControllers = pointControllers;
        }

        public static SpawnSystem CreateSpawnSystem(ISpawnSystemDescription description)
        {
            var points = GameObject.FindGameObjectsWithTag(TagManager.SPAWN_POINT);
            var pointControllers = new List<ISpawnPointController>();
            foreach (var point in points)
            {
                if (point.TryGetComponent<ISpawnPointView>(out var view))
                {
                    var model = description[view.Id];
                    model.SetPointPosition(view.Transform.position);
                    model.SetPointRotation(view.Transform.rotation);
                    pointControllers.Add(new SpawnPointController(model, view));
                }
            }

            return new SpawnSystem(pointControllers);
        }

        public IEnumerable<ISpawnPointController> GetSpawnPointsByPredicate(Func<ISpawnPointController, bool> predicate)
        {
            return _pointControllers.Where(predicate);
        }
    }
}