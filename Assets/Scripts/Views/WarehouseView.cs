using System;
using DroneBase.Animations;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class WarehouseView : MonoBehaviour, IWarehouseView
    {
        public event Action Selected;
        public event Action<ResourcesContainer> ResourcesProvide;

        [SerializeField] private SelectSpriteAnimator _animator;
        [SerializeField] private ActionArea _actionArea;

        private IWarehouseController _controller;
        private IWarehouseModel _model;

        public int Id => _model.Id;
        public Vector3 InteractivePoint => _actionArea.InteractivePoint;
        public EntityType Type => _model.Type;
        public ITarget GetTarget => _controller;
        public Transform Transform => transform;

        public void Init(IWarehouseController controller, IWarehouseModel model)
        {
            _controller = controller;
            _model = model;
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

        public void SetInteractivePoint(Vector3 point)
        {
            _actionArea.SetInteractivePoint(point);
        }
        
        private void OnMouseDown()
        {
            Selected?.Invoke();
        }

        public ResourcesContainer GetResources(int quantity)
        {
            return _controller.GetResources(quantity);
        }
    }
}