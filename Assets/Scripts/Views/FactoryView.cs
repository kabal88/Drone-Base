using System;
using DroneBase.Animations;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public sealed class FactoryView : MonoBehaviour, IFactoryView
    {
        public event Action Selected;
        public event Action<ResourcesContainer> ResourcesReceived;

        [SerializeField] private SelectSpriteAnimator _animator;
        [SerializeField] private Transform _actionAreaTransform;

        private IFactoryModel _model;
        private IFactoryController _controller;

        public int Id => _model.Id;
        public Vector3 InteractivePoint => _actionAreaTransform.position;
        public EntityType Type => _model.Type;
        public ITarget GetTarget => _controller;
        public Transform Transform => transform;

        public void Init(IFactoryController controller, IFactoryModel model)
        {
            _model = model;
            _controller = controller;
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
        
        public void SetInteractivePoint(Vector3 point)
        {
            _actionAreaTransform.position = point;
        }
        
        public void TakeResources(ResourcesContainer container)
        {
            OnResourcesReceived(container);
        }

        private void OnResourcesReceived(ResourcesContainer container)
        {
            ResourcesReceived?.Invoke(container);
        }
    }
}