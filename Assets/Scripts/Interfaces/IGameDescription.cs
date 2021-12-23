namespace DroneBase.Interfaces
{
    public interface IGameDescription: IDescription
    {
        IGameModel GameModel { get; }
    }
}