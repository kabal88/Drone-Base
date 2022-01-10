using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class CanvasModel : ICanvasModel
    {
        public bool IsAlarmOn { get; private set; }
        public float PlaneDistance { get; private set; }

        public CanvasModel(bool isAlarmOn, float planeDistance)
        {
            IsAlarmOn = isAlarmOn;
            PlaneDistance = planeDistance;
        }

        public void SetAlarm(bool isAlarmOn)
        {
            IsAlarmOn = isAlarmOn;
        }

        public void SetPlaneDistance(float distance)
        {
            PlaneDistance = distance;
        }
    }
}