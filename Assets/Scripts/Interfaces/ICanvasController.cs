using System;

namespace DroneBase.Interfaces
{
    public interface ICanvasController
    {
        event Action AlarmClicked;
        void SetAlarm(bool isOn);
    }
}