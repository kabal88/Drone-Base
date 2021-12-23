using DroneBase.Controllers;
using DroneBase.Libraries;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private DroneView _droneView;
        [SerializeField] private Library _library = new Library();
        private GameController _gameController;

        private void Start()
        {
            _library.LoadAllAssets();
            _library.Init();
            _gameController = new GameController(_library,_camera, _droneView);
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