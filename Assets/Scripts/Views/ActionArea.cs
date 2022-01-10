using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class ActionArea : MonoBehaviour , IActionArea
    {
        public Vector3 InteractivePoint => transform.position;

        public IView GetView { get; private set; }

        public void SetInteractivePoint(Vector3 point)
        {
            transform.position = point;
        }

        public void SetView(IView view)
        {
            GetView = view;
        }
    }
}