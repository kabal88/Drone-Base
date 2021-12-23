using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class CameraView : MonoBehaviour, IView
    {
        public Transform Transform => transform;
    }
}