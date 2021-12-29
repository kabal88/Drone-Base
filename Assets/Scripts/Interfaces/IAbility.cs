namespace DroneBase.Interfaces
{
    public interface IAbility
    {
        void Execute(ISelect owner, ITarget target);
    }
}