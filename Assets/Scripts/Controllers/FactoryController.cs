using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public sealed class FactoryController : IFactoryController, IDisposable
    {
        public event Action<ISelect> Selected;
        public event Action<ResourcesContainer> ResourcesReceived;

        private IFactoryModel _model;
        private IFactoryView _view;

        public ITarget GetTarget => this;
        public ISelect GetSelect => this;
        public EntityType Type => _model.Type;
        public TargetData TargetData => _model.GetTargetData;

        private FactoryController(IFactoryModel model, IFactoryView view)
        {
            _model = model;
            _view = view;
        }

        public static FactoryController CreateFactoryController(IFactoryDescription description,
            SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                .GetComponent<IFactoryView>();

            var model = description.BuildingModel;

            model.SetPosition(view.Transform.position);
            model.SetRotation(view.Transform.rotation);
            model.SetInteractivePoint(view.InteractivePoint);

            var factory = new FactoryController(model, view);
            view.Init(factory, model);
            
            ServiceLocator.Get<ISelectionService>().RegisterObject(factory);
            view.Selected += factory.OnSelected;

            return factory;
        }

        public void SetSelection()
        {
            _view.PlaySelectionAnimation();
        }

        public void ClearSelection()
        {
            _view.StopSelectionAnimation();
        }

        private void OnSelected()
        {
            Selected?.Invoke(this);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
            _view.Selected -= OnSelected;
        }
        
        public void TakeResources(ResourcesContainer container)
        {
            _model.AddResource(container);
        }
    }
}