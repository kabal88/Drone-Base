namespace DroneBase.Interfaces
{
    public interface IUnitContext : IContext
    {
        public IMoveSystem MoveSystem { get; }
    }
}