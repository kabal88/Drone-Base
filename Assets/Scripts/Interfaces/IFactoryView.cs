namespace DroneBase.Interfaces
{
    public interface IFactoryView : IBuildingView<IFactoryController, IFactoryModel>, IInteractive, IResourceReceiver
    {
    }
}