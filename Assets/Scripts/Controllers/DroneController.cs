using DroneBase.Data;
using DroneBase.Interfaces;
using DroneBase.Systems;
using DroneBase.Views;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Controllers
{
    public class DroneController : IUnitController
    {
        private IDroneModel _droneModel;
        private IDroneView _droneView;
        private IMoveSystem _moveSystem;
        private IAbilitiesSystem _abilitiesSystem;

        private DroneController(
            IDroneModel model,
            IDroneView view,
            IMoveSystem moveSystem
           // IAbilitiesSystem abilitiesSystem,
           // INavigationSystem navigationSystem
            )
        {
            _moveSystem = moveSystem;
            //_abilitiesSystem = abilitiesSystem;
            _droneModel = model;
            _droneView = view;
        }

        public static DroneController CreateDroneController(IDroneDescription description, SpawnPointData pointData)
        {
            var droneView =
                Object.Instantiate(description.DronePrefab, pointData.PointPosition, pointData.Rotation).GetComponent<DroneView>();
            var drone = new DroneController(description.DroneModel, droneView, new NavMeshMovingSystem(droneView.NavMeshAgent));

            return drone;
        }
        
        public void SetTarget(Vector3 target)
        {
            CustomDebug.Log($"Unit set target = {target}");
            _droneModel.SetTarget(target);
           // _droneModel.SetPath(_navigationSystem.CalculatePath(_droneView.Transform.position, target));
            _moveSystem.SetDestination(target);
        }
    }
}