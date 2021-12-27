using System;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Services;
using DroneBase.States;
using DroneBase.Systems;
using UnityEngine;

namespace DroneBase.Controllers
{
    public sealed class DroneController : IUnitController, IDisposable
    {
        public event Action<ISelect> Selected;

        private IDroneModel _droneModel;
        private IDroneView _droneView;
        private IMoveSystem _moveSystem;
        private IAbilitiesSystem _abilitiesSystem;
        private IUnitState _unitState;

        public EntityType Type => _droneModel.Type;
        public ISelect GetSelect => this;
        public Vector3? PreviousTarget => _droneModel.PreviousTarget;
        public IMoveSystem MoveSystem => _moveSystem;

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
                GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                    .GetComponent<IDroneView>();

            droneView.SetEntityType(description.Model.Type);

            var drone = new DroneController(description.Model, droneView,
                new NavMeshMovingSystem(droneView.NavMeshAgent));

            ServiceLocator.Get<ISelectionService>().RegisterObject(drone);
            drone.SetState(new DroneNormalState(drone));
            return drone;
        }

        public void SetTarget(ITarget target)
        {
            _unitState.SetTarget(target,_droneModel);
        }

        public void SetTarget(Vector3 point)
        {
            _unitState.SetTarget(point,_droneModel);
        }

        public void SetSelection()
        {
            _unitState.SetSelection(_droneView);
        }

        public void ClearSelection()
        {
            _unitState.ClearSelection(_droneView);
        }

        public void SetState(IUnitState state)
        {
            _unitState = state;
            _unitState.EnterState();
        }

        private void OnViewSelected(ISelect obj)
        {
            _unitState.OnViewSelected(this,Selected);
        }

        public void Dispose()
        {
            _droneView.Selected -= OnViewSelected;
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
        }
    }
}