namespace DroneBase.Interfaces
{
    public interface IDroneBaseView :IBuildingView<IDroneBaseController,IDroneBaseModel>, IInteractive
    {
        void SetGate(bool isOpen);
    }
}