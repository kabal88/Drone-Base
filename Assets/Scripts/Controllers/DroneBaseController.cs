using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class DroneBaseController : IDroneBaseController, IDisposable
    {
        public event Action<ISelect> Selected;

        private IDroneBaseModel _model;
        private IDroneBaseView _view;

        public int Id =>_model.Id;
        public ITarget GetTarget => this;
        public ISelect GetSelect => this;
        public EntityType Type => _model.Type;
        public TargetData TargetData => _model.GetTargetData;

        
        private DroneBaseController(IDroneBaseModel model, IDroneBaseView view)
        {
            _model = model;
            _view = view;
        }
        
        public static DroneBaseController CreateDroneBaseController(IDroneBaseDescription description,
            SpawnPointData pointData)
        {
            var view = GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                .GetComponent<IDroneBaseView>();
            var model = description.BuildingModel;

            model.SetPosition(view.Transform.position);
            model.SetRotation(view.Transform.rotation);

            var controller = new DroneBaseController(model, view);
            view.Init(controller, model);

            ServiceLocator.Get<ISelectionService>().RegisterObject(controller);
            view.Selected += controller.OnSelected;

            return controller;
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
        
        public void SetGate(bool isOpen)
        {
            _view.SetGate(isOpen);
        }

        public void Dispose()
        {
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
            _view.Selected -= OnSelected;
        }
    }
}