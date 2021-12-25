using DroneBase.Controllers;
using DroneBase.Identifier;
using DroneBase.Libraries;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase
{
    public sealed class GameRoot : MonoBehaviour
    {
        [SerializeField] private IdentifierContainer _gameIdentifierContainer;
        [SerializeField] private Library _library = new Library();
        private GameController _gameController;

        private void Start()
        {
            _library.LoadAllAssets();
            _library.Init();
            _gameController =
                GameController.CreateGameController(_library.GetGameDescription(_gameIdentifierContainer.Id), _library);
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