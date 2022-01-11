namespace DroneBase.Interfaces
{
    public interface IDroneBaseController :IBuildingController
    {
        void SetGate(bool isOpen);
    }
}