using System;
using System.Collections.Generic;
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
        public event Action EnterSaveArea;

        private readonly IDroneModel _model;
        private readonly IDroneView _view;
        private IUnitState _unitState;

        public bool IsInSaveArea => _model.InSaveArea;
        public int Id => _model.Id;
        public EntityType Type => _model.Type;
        public ISelect GetSelect => this;
        public TargetData PreviousTarget => _model.PreviousTarget;
        public IMoveSystem MoveSystem { get; }
        public IUnitModel Model => _model;
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
            _model = model;
            _view = view;
            _view.Selected += OnViewSelected;
        }

        public static DroneController CreateDroneController(IDroneDescription description, SpawnPointData pointData,
            Dictionary<int, IAbilityDescription> abilityDescriptions)
        {
            var view =
                GameObject.Instantiate(description.Prefab, pointData.Position, pointData.Rotation)
                    .GetComponent<IDroneView>();

            var model = description.Model;

            view.SetNavMeshSettings(model.Speed, model.RotationSpeed);
            view.SetID(model.Id);

            var abilitySystem =
                AbilitySystem.CreateAbilitiesSystem(description.AvailableAbilitiesMap, abilityDescriptions);

            var drone = new DroneController(model, view, new NavMeshMovingSystem(view.NavMeshAgent), abilitySystem);

            ServiceLocator.Get<ISelectionService>().RegisterObject(drone);
            ServiceLocator.Get<IFixUpdateService>().RegisterObject(drone);
            view.SensorEnterTrigger += drone.OnSensorEnterTrigger;
            view.SensorExitTrigger += drone.OnSensorExitTrigger;

            drone.SetState(new DroneIdleState(drone));
            return drone;
        }

        public void SetTarget(TargetData target)
        {
            _unitState.SetTarget(target, _model);
        }

        public void SetSelection()
        {
            _unitState.SetSelection(_view);
        }

        public void ClearSelection()
        {
            _unitState.ClearSelection(_view);
        }

        public void SetState(IUnitState state)
        {
            _model.SetPreviousState(_unitState);
            _unitState = state;
            _unitState.EnterState();
        }

        public void PreviousState()
        {
            _unitState.ExitState();
            SetState(_model.PreviousState);
            SetTarget(_model.PreviousTarget);
        }

        private void OnViewSelected()
        {
            _unitState.OnViewSelected(this, Selected);
        }

        private void OnSensorEnterTrigger(Collider collider)
        {
            _unitState.OnSensorEnterTrigger(collider);
        }

        private void OnSensorExitTrigger(Collider collider)
        {
            _unitState.OnSensorExitTrigger(collider);
        }

        public void TakeResources(ResourcesContainer container)
        {
            _model.SetResourcesContainer(container);
            _view.SetResourceVisibility(true);
        }

        public void FixedUpdateLocal()
        {
            _unitState.FixedUpdateLocal();
            _view.SetAnimationVelocity(MoveSystem.SqrVelocity / (_model.Speed * _model.Speed));
        }


        public ResourcesContainer GetResources(int quantity)
        {
            var resource = _model.Container;
            _model.SetResourcesContainer(new ResourcesContainer());
            _view.SetResourceVisibility(false);
            return resource;
        }

        public void SetInSaveArea(bool inSave)
        {
            _model.SetInSaveArea(inSave);
            if (inSave)
            {
                EnterSaveArea?.Invoke();
            }
        }

        public void Dispose()
        {
            _view.Selected -= OnViewSelected;
            _view.SensorEnterTrigger -= OnSensorEnterTrigger;
            _view.SensorExitTrigger -= OnSensorExitTrigger;
            ServiceLocator.Get<IFixUpdateService>().UnRegisterObject(this);
            ServiceLocator.Get<ISelectionService>().UnRegisterObject(this);
        }
    }
}