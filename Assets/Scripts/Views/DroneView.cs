using System;
using DroneBase.Animations;
using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Views
{
    public sealed class DroneView : MonoBehaviour, IDroneView
    {
        public event Action Selected;
        public event Action<Collider> SensorCollide;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SelectSpriteAnimator _animator;
        [SerializeField] private DroneSensor _sensor;

        public int Id { get; private set; }

        public Transform Transform => transform;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        public void OnEnable()
        {
            _sensor.SensorCollide += OnSensorCollide;
        }

        public void OnDisable()
        {
            _sensor.SensorCollide -= OnSensorCollide;
        }

        public void SetNavMeshSettings(float speed, float rotationSpeed)
        {
            _navMeshAgent.speed = speed;
            _navMeshAgent.angularSpeed = rotationSpeed;
        }

        public void SetID(int id)
        {
            Id = id;
        }

        public void PlaySelectionAnimation()
        {
            _animator.ShowSelectedAnimation();
        }

        public void StopSelectionAnimation()
        {
            _animator.HideSelectAnimation();
        }

        private void OnMouseDown()
        {
            Selected?.Invoke();
        }

        private void OnSensorCollide(Collider other)
        {
            SensorCollide?.Invoke(other);
        }
    }
}