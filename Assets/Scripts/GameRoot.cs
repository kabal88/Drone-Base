using DroneBase.Controllers;
using UnityEngine;

namespace DroneBase
{
    public class GameRoot : MonoBehaviour
    {
        private GameController _gameController;

        private void Start()
        {
            _gameController = new GameController();
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