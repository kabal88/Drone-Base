using System;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DroneBase.Views
{
    public sealed class DroneView : MonoBehaviour, IDroneView
    {
        public event Action<ISelectable> Selected;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpriteRenderer _selectSpriteRenderer;
        

        public Transform Transform => transform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EntityType Type => EntityType.Unit;

        public void SetSelection()
        {
            _selectSpriteRenderer.enabled = true;
        }

        public void ClearSelection()
        {
            _selectSpriteRenderer.enabled = false;
        }

        private void OnMouseDown()
        {
            Selected?.Invoke(this);
        }
    }
}