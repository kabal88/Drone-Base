namespace DroneBase.Interfaces
{
    public interface ICanvasModel
    {
        bool IsAlarmOn { get; }
        float PlaneDistance { get; }
        void SetAlarm(bool isAlarmOn);
        void SetPlaneDistance(float distance);
    }
}