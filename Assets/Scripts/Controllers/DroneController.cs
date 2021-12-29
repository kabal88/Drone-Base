using System;
using DroneBase.Abilities;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Libraries;
using DroneBase.Services;
using DroneBase.States;
using DroneBase.Systems;
using UnityEngine;

namespace DroneBase.Controllers
{
    public sealed class DroneController : IDroneController, IDisposable
    {
        public event Action<ISelect> Selected;
        public event Action<ResourcesContainer> ResourcesReceived;

        private IDroneModel _droneModel;
        private IDroneView _droneView;
        private IMoveSystem _moveSystem;
        private IAbilitiesSystem _abilitiesSystem;
        private IUnitState _unitState;

        public EntityType Type => _droneModel.Type;
        public ISelect GetSelect => this;
        public Vector3? PreviousTarget => _droneModel.PreviousTarget;
        public IMoveSystem MoveSystem => _moveSystem;
        public IUnitModel Model => _droneModel;

        private DroneController(
            IDroneModel model,
            IDroneView view,
            IMoveSystem moveSystem,
            IAbilitiesSystem abilitiesSystem
        )
        {
            _moveSystem = moveSystem;
            _abilitiesSystem = abilitiesSystem;
            _droneModel = model;
            _droneView = view;
            _droneView.Selected += OnViewSelected;
        }

        public static DroneController CreateDroneController(IDroneDescription description, SpawnPointData pointData,
            Library library) //TODO: убрать передачу всей библиотеки
        {
            var view =
                GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                    .GetComponent<IDroneView>();

            var model = description.Model;

            view.SetNavMeshSettings(model.Speed, model.RotationSpeed);

            var abilitySystem = AbilitySystem.CreateAbilitiesSystem(description.AvailableAbilitiesMap, library);

            var drone = new DroneController(model, view, new NavMeshMovingSystem(view.NavMeshAgent), abilitySystem);

            ServiceLocator.Get<ISelectionService>().RegisterObject(drone);
            view.SensorCollide += drone.OnSensorCollide;

            drone.SetState(new DroneIdleState(drone));
            return drone;
        }

        public void SetTarget(TargetData target)
        {
            _unitState.SetTarget(target, _droneModel);
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

        private void OnViewSelected()
        {
            _unitState.OnViewSelected(this, Selected);
        }

        private void OnSensorCollide(Collider collider)
        {
            CustomDebug.Log($"sensor find: {collider.name}");
            _unitState.OnSensorCollide(collider);
        }

        public void TakeResources(ResourcesContainer container)
        {
            _droneModel.SetResourcesContainer(container);
        }

        public void AskForResources(IResourceReceiver receiver, int quantity)
        {
            receiver.TakeResources(_droneModel.Container);
        }

        public void Dispose()
        {
            _droneView.Selected -= OnViewSelected;
            _droneView.SensorCollide -= OnSensorCollide;
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
        }
    }
}