using DroneBase.Controllers;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private DroneView _droneView;
        private GameController _gameController;

        private void Start()
        {
            _gameController = new GameController(_camera, _droneView);
            _gameController.StartGame();
        }

        private void Update()
        {
            _gameController.UpdateLocal(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _gameController.FixedUpdateLocal();
        }
    }
}