namespace DroneBase.Interfaces
{
    public interface IState<T> where T :IContext
    {
        public T Drone { get; }
        void EnterState();
        void ExitState();
    }
}