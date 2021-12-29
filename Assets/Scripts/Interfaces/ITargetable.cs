namespace DroneBase.Interfaces
{
    public interface ITargetable: IEntityType
    {
        public ITarget GetTarget { get; }
    }
}