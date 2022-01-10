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
        [SerializeField] private ActionArea _actionArea;

        private IFactoryModel _model;
        private IFactoryController _controller;

        public int Id => _model.Id;
        public Vector3 InteractivePoint => _actionArea.InteractivePoint;
        public EntityType Type => _model.Type;
        public ITarget GetTarget => _controller;
        public Transform Transform => transform;

        public void Init(IFactoryController controller, IFactoryModel model)
        {
            _model = model;
            _controller = controller;
            _actionArea.SetView(this);
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
            _actionArea.SetInteractivePoint(point);
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