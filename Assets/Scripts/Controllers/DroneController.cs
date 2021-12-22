using DroneBase.Interfaces;

namespace DroneBase.Controllers
{
    public class DroneController
    {
        private IDroneModel _droneModel;
        private IView _droneView;
        private IMoveSystem _moveSystem;
        private IAbilitiesSystem _abilitiesSystem;

        public DroneController(IDroneModel model, IView view, IMoveSystem moveSystem, IAbilitiesSystem abilitiesSystem)
        {
            _moveSystem = moveSystem;
            _abilitiesSystem = abilitiesSystem;
            _droneModel = model;
            _droneView = view;
        }
    }
}