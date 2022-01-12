namespace DroneBase.Interfaces
{
    public interface IDroneBaseView :IBuildingView<IDroneBaseController,IDroneBaseModel>, IInteractive, ISaveArea
    {
        void SetGate(bool isOpen);
    }
}