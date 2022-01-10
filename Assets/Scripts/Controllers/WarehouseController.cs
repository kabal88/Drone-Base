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
        public event Action<ResourcesContainer> ResourcesProvide;

        private IWarehouseModel _model;
        private IWarehouseView _view;

        public int Id => _model.Id;
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

            return warehouse;
        }

        private void OnAskedForResources(IResourceReceiver receiver, int qty)
        {
            if (_model.TryGetResource(new ResourcesContainer(qty, _model.StorageResourceType), out qty))
            {
                receiver.TakeResources(new ResourcesContainer(qty, _model.StorageResourceType));
            }
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

        public void AskForResources(IResourceReceiver receiver, int quantity)
        {
            OnAskedForResources(receiver, quantity);
        }

        public ResourcesContainer GetResources(int quantity)
        {
            return _model.TryGetResource(new ResourcesContainer(quantity, _model.StorageResourceType), out quantity)
                ? new ResourcesContainer(quantity, _model.StorageResourceType)
                : new ResourcesContainer();
        }
    }
}