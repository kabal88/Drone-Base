using DroneBase.Interfaces;

namespace DroneBase.Controllers
{
    public class SpawnPointController : ISpawnPointController
    {
        public ISpawnPointModel Model { get; }
    }
}