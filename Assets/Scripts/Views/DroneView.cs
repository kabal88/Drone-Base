using System;
using DroneBase.Animations;
using DroneBase.Interfaces;
using DroneBase.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Views
{
    public sealed class DroneView : MonoBehaviour, IDroneView
    {
        public event Action Selected;
        public event Action<Collider> SensorEnterTrigger;
        public event Action<Collider> SensorExitTrigger;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SelectSpriteAnimator _selectAnimator;
        [SerializeField] private DroneSensor _sensor;
        [SerializeField] private Animator _meshAnimator;
        [SerializeField] private GameObject _oilSphere;

        public int Id { get; private set; }
        public Transform Transform => transform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        public void OnEnable()
        {
            _sensor.SensorEnterTrigger += OnSensorEnterTrigger;
            _sensor.SensorExitTrigger += OnSensorExitTrigger;
        }

        public void OnDisable()
        {
            _sensor.SensorEnterTrigger -= OnSensorEnterTrigger;
            _sensor.SensorExitTrigger -= OnSensorExitTrigger;
        }

        public void SetAnimationVelocity(float velocity)
        {
            _meshAnimator.SetFloat(AnimatorTagManager.Speed, velocity);
        }

        public void SetResourceVisibility(bool isVisible)
        {
            _oilSphere.SetActive(isVisible);
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
            _selectAnimator.ShowSelectedAnimation();
        }

        public void StopSelectionAnimation()
        {
            _selectAnimator.HideSelectAnimation();
        }

        private void OnMouseDown()
        {
            Selected?.Invoke();
        }

        private void OnSensorEnterTrigger(Collider other)
        {
            SensorEnterTrigger?.Invoke(other);
        }

        private void OnSensorExitTrigger(Collider obj)
        {
            SensorExitTrigger?.Invoke(obj);
        }
    }
}