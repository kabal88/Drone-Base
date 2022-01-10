namespace DroneBase.Interfaces
{
    public interface IState<T> where T :IContext
    {
        public T Context { get; }
        void EnterState();
        void ExitState();
    }
}