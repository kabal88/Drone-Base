using System;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICanvasView
    {
        event Action AlarmClicked;
        
        void Init(ICamera camera, float planeDistance);
        void SetCamera(Camera camera);
        void SetAlarm(bool isOn);
    }
}