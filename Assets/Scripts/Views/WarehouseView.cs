using System;
using DroneBase.Animations;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class WarehouseView : MonoBehaviour, IWarehouseView
    {
        public event Action Selected;
        public event Action<IResourceReceiver> AskedForResources;

        [SerializeField] private SelectSpriteAnimator _animator;
        [SerializeField] private Transform _actionAreaTransform;
        
        private IWarehouseController _controller;
        private IWarehouseModel _model;
        
        public Vector3 InteractivePoint => _actionAreaTransform.position;
        public EntityType Type => _model.Type;
        public ITarget GetTarget => _controller;
        public Transform Transform => transform;
        
        public void Init(IWarehouseController controller, IWarehouseModel model)
        {
            _controller = controller;
            _model = model;
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
            _actionAreaTransform.position = point;
        }
        
        public void AskForResources(IResourceReceiver receiver)
        {
            AskedForResources?.Invoke(receiver);
        }
    }
}