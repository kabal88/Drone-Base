using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class FactoryController : IFactoryController
    {
        public event Action<ISelectable> Selected;
        public event Action<ITargetable> Targeted;
        public EntityType Type { get; }

        private IFactoryModel _model;
        private IFactoryView _view;

        private FactoryController(IFactoryModel model, IFactoryView view)
        {
            _model = model;
            _view = view;
        }

        public static FactoryController CreateFactoryController(IFactoryDescription description, SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation).GetComponent<IFactoryView>();

            var factory = new FactoryController(description.BuildingModel, view);
            ServiceLocator.Get<ISelectionService>().RegisterObject(factory);

            return factory;
        }

        public void SetSelection()
        {
            throw new NotImplementedException();
        }

        public void ClearSelection()
        {
            throw new NotImplementedException();
        }
    }
}