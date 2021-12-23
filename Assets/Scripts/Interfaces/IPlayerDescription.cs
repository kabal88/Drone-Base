namespace DroneBase.Interfaces
{
    public interface IPlayerDescription : IDescription
    {
        IPlayerModel PlayerModel { get; }
    }
}