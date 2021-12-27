using System;
using DroneBase.Animations;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Views
{
    public sealed class DroneView : MonoBehaviour, IDroneView
    {
        public event Action<ISelect> Selected;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SelectSpriteAnimator _animator;


        public Transform Transform => transform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EntityType Type { get; private set; }
        public ISelect GetSelect => this;
    

        public void SetSelection()
        {
            _animator.ShowSelectedAnimation();
        }

        public void ClearSelection()
        {
            _animator.HideSelectAnimation();
        }

        public void SetEntityType(EntityType type)
        {
            Type = type;
        }

        private void OnMouseDown()
        {
            Selected?.Invoke(this);
        }
    }
}