using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class WarehouseController : IWarehouseController, IDisposable
    {
        public event Action<ISelect> Selected;
        
        private IWarehouseModel _model;
        private IWarehouseView _view;
        
        public ITarget GetTarget => this;
        public ISelect GetSelect => this;
        public EntityType Type => _model.Type;
        public TargetData TargetData => _model.GetTargetData;
        
        public WarehouseController(IWarehouseModel model, IWarehouseView view)
        {
            _model = model;
            _view = view;
        }
        
        public static WarehouseController CreateWarehouseController(IWarehouseDescription description,
            SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                .GetComponent<IWarehouseView>();

            var model = description.BuildingModel;

            model.SetPosition(view.Transform.position);
            model.SetRotation(view.Transform.rotation);
            model.SetInteractivePoint(view.InteractivePoint);

            var warehouse = new WarehouseController(model, view);
            view.Init(warehouse, model);
            
            ServiceLocator.Get<ISelectionService>().RegisterObject(warehouse);
            view.Selected += warehouse.OnSelected;
            view.AskedForResources += warehouse.OnAskedForResources;

            return warehouse;
        }

        private void OnAskedForResources(IResourceReceiver receiver)
        {
           var resource = _model.AddResource()
            receiver.TakeResources(_model.ad);
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
    }
}