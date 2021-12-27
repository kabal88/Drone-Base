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
        public event Action<ITarget> Targeted;

        private IFactoryModel _model;
        private IFactoryView _view;

        public ITarget GetTarget => this;
        public ISelect GetSelect => this;
        public EntityType Type => _model.Type;
        public TargetData TargetData => new TargetData(_model.Position);

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

            var factory = new FactoryController(model, view);

            ServiceLocator.Get<ISelectionService>().RegisterObject(factory);
            view.Selected += factory.OnSelected;
            view.SetTarget(factory);

            return factory;
        }

        public void SetSelection()
        {
            _view.SetSelection();
        }

        public void ClearSelection()
        {
            _view.ClearSelection();
        }

        private void OnSelected(ISelect obj)
        {
            Selected?.Invoke(obj);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
            _view.Selected -= OnSelected;
        }
    }
}