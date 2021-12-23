using DroneBase.Data;
using DroneBase.Libraries;

namespace DroneBase.Interfaces
{
    public interface IGameModel
    {
        IUpdatable UpdateService { get; }
        IFixUpdatable FixUpdateService { get; }
        Library Library { get; }
        GamePresetData PresetData { get; }

        void SetUpdateService(IUpdatable service);
        void SetFixUpdateService(IFixUpdatable service);
        void Init(Library library);
    }
}