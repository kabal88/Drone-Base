using DroneBase.Data;

namespace DroneBase.Interfaces
{
    public interface IResourceGiver
    {
        void AskForResources(IResourceReceiver receiver);
    }
}