using System;
using DroneBase.Interfaces;
using DroneBase.UI;
using UnityEngine;

namespace DroneBase.Views
{
    public class CanvasView : MonoBehaviour, ICanvasView
    {
        public event Action AlarmClicked;
        
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CustomButton _alarmButton;

        private void OnEnable()
        {
            _alarmButton.OnClick += OnAlarmClicked;
        }

        private void OnDisable()
        {
            _alarmButton.OnClick -= OnAlarmClicked;
        }

        public void Init(ICamera cam, float planeDistance)
        {
            _canvas.worldCamera = cam.Camera;
            _canvas.planeDistance = planeDistance;
        }

        public void SetCamera(Camera cam)
        {
            _canvas.worldCamera = cam;
        }

        private void OnAlarmClicked()
        {
            AlarmClicked?.Invoke();
        }

        public void SetAlarm(bool isOn)
        {
            CustomDebug.Log($"isOn = {isOn}");
        }
    }
}