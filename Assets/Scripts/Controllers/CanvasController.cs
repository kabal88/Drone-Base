using System;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Controllers
{
    public class CanvasController : ICanvasController, IDisposable
    {
        public event Action AlarmClicked;

        private ICanvasView _view;
        private ICanvasModel _model;

        private CanvasController(ICanvasView view, ICanvasModel model)
        {
            _view = view;
            _model = model;
        }

        public static CanvasController CreateCanvasController(ICanvasDescription description, ICamera cam)
        {
            var view = GameObject.Instantiate(description.Prefab).GetComponent<ICanvasView>();
            var model = description.Model;
            var controller = new CanvasController(view, model);
            view.Init(cam, model.PlaneDistance);
            view.AlarmClicked += controller.OnAlarmClicked;
            
            controller.SetAlarm(model.IsAlarmOn);
            
            return controller;
        }

        public void SetAlarm(bool isOn)
        {
            _model.SetAlarm(isOn);
            _view.SetAlarm(isOn);
        }


        private void OnAlarmClicked()
        {
            AlarmClicked?.Invoke();
        }

        public void Dispose()
        {
            _view.AlarmClicked -= OnAlarmClicked;
        }
    }
}