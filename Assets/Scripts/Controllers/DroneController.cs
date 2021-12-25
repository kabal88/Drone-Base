using System;
using DroneBase.Data;
using DroneBase.Interfaces;
using DroneBase.Services;
using DroneBase.Systems;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase.Controllers
{
    public sealed class DroneController : IUnitController, IDisposable
    {
        public event Action<ISelectable> Selected;
        
        private IDroneModel _droneModel;
        private IDroneView _droneView;
        private IMoveSystem _moveSystem;
        private IAbilitiesSystem _abilitiesSystem;

        private DroneController(
            IDroneModel model,
            IDroneView view,
            IMoveSystem moveSystem
           // IAbilitiesSystem abilitiesSystem,
        )
        {
            _moveSystem = moveSystem;
            //_abilitiesSystem = abilitiesSystem;
            _droneModel = model;
            _droneView = view;
            _droneView.Selected += OnViewSelected;
        }

        public static DroneController CreateDroneController(IDroneDescription description, SpawnPointData pointData)
        {
            var droneView =
                GameObject.Instantiate(description.DronePrefab, pointData.Position, pointData.Rotation).GetComponent<DroneView>();
            var drone = new DroneController(description.DroneModel, droneView, new NavMeshMovingSystem(droneView.NavMeshAgent));
            
            ServiceLocator.Get<ISelectionService>().RegisterObject(drone);
            return drone;
        }

        public void SetNavTarget(Vector3 target)
        {
            CustomDebug.Log($"Unit set target = {target}");
            _droneModel.SetNavTarget(target);
           // _droneModel.SetPath(_navigationSystem.CalculatePath(_droneView.Transform.position, target));
            _moveSystem.SetDestination(target);
        }

        public void SetSelection()
        {
            _droneView.SetSelection();
        }

        public void ClearSelection()
        {
            _droneView.ClearSelection();
        }

        private void OnViewSelected(ISelectable obj)
        {
            CustomDebug.Log($"OnView Clicked");
            Selected?.Invoke(this);
        }

        public void Dispose()
        {
            _droneView.Selected -= OnViewSelected;
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
        }
    }
}