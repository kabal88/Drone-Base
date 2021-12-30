namespace DroneBase.Interfaces
{
    public interface IUnitContext : IContext
    {
        public IMoveSystem MoveSystem { get; }
        public IUnitModel Model { get; }
        public IAbilitiesSystem AbilitiesSystem { get; }
    }
}