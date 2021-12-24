namespace DroneBase.Interfaces
{
    public interface ISpawnSystemDescription : IDescription
    {
        ISpawnPointModel this[int key] { get; }
    }
}