using DroneBase.Data;
using DroneBase.Interfaces;
using DroneBase.Libraries;

namespace DroneBase.Models
{
    public class GameModel : IGameModel
    {
        public IUpdatable UpdateService { get; private set; }
        public IFixUpdatable FixUpdateService { get; private set; }
        public Library Library { get; private set; }
        public GamePresetData PresetData { get; }
        
        public GameModel(GamePresetData presetData)
        {
            PresetData = presetData;
        }

        public void Init(Library library)
        {
            Library = library;
        }

        public void SetUpdateService(IUpdatable service)
        {
            UpdateService = service;
        }

        public void SetFixUpdateService(IFixUpdatable service)
        {
            FixUpdateService = service;
        }
    }
}