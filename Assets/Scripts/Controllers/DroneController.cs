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
        public event Action<ResourcesContainer> ResourcesProvide;

        private IDroneModel _droneModel;
        private IDroneView _droneView;
        private IUnitState _unitState;

        public int Id => _droneModel.Id;
        public EntityType Type => _droneModel.Type;
        public ISelect GetSelect => this;
        public Vector3? PreviousTarget => _droneModel.PreviousTarget;
        public IMoveSystem MoveSystem { get; }
        public IUnitModel Model => _droneModel;
        public IAbilitiesSystem AbilitiesSystem { get; }


        private DroneController(
            IDroneModel model,
            IDroneView view,
            IMoveSystem moveSystem,
            IAbilitiesSystem abilitiesSystem
        )
        {
            MoveSystem = moveSystem;
            AbilitiesSystem = abilitiesSystem;
            _droneModel = model;
            _droneView = view;
            _droneView.Selected += OnViewSelected;
        }

        public static DroneController CreateDroneController(IDroneDescription description, SpawnPointData pointData,
            Library library)                            //TODO: убрать передачу всей библиотеки
        {
            var view =
                GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                    .GetComponent<IDroneView>();

            var model = description.Model;

            view.SetNavMeshSettings(model.Speed, model.RotationSpeed);
            view.SetID(model.Id);

            var abilitySystem = AbilitySystem.CreateAbilitiesSystem(description.AvailableAbilitiesMap, library);

            var drone = new DroneController(model, view, new NavMeshMovingSystem(view.NavMeshAgent), abilitySystem);

            ServiceLocator.Get<ISelectionService>().RegisterObject(drone);
            ServiceLocator.Get<IFixUpdateService>().RegisterObject(drone);
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
            ServiceLocator.Get<IFixUpdateService>().UnRegisterObject(this);
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
        }

        public void FixedUpdateLocal()
        {
            _unitState.FixedUpdateLocal();
        }


        public ResourcesContainer GetResources(int quantity)
        {
            var resource = _droneModel.Container;
            _droneModel.SetResourcesContainer(new ResourcesContainer());
            return resource;
        }
    }
}