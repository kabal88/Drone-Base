using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class CameraView : MonoBehaviour, ICameraView
    {
        [SerializeField] private Camera _camera;
        
        public Transform Transform => transform;
        public Camera Camera => _camera;
    }
}