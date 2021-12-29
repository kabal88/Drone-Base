using System;
using DroneBase.Animations;
using DroneBase.Data;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public sealed class FactoryView: MonoBehaviour, IFactoryView

    {
        public event Action<ISelect> Selected;
        public event Action<ITarget> Targeted;

        [SerializeField] private SelectSpriteAnimator _animator;
        [SerializeField] private Transform _actionAreaTransform;

        private ITarget _target;
        
        public Transform Transform => transform;
        public EntityType Type { get; private set; }
        public ISelect GetSelect => this;
        public ITarget GetTarget => _target;
        public TargetData TargetData => _target.TargetData;
        public Vector3 InteractivePoint => _actionAreaTransform.position;

        public void SetEntityType(EntityType type)
        {
            Type = type;
        }

        public void SetTarget(ITarget target)
        {
            _target = target;
        }

        public void SetSelection()
        {
            _animator.ShowSelectedAnimation();
        }

        public void ClearSelection()
        {
            _animator.HideSelectAnimation();
        }

        private void OnMouseDown()
        {
            OnSelected(this);
        }

        private void OnSelected(ISelect obj)
        {
            Selected?.Invoke(obj);
        }

        public void SetInteractivePoint(Vector3 point)
        {
            _actionAreaTransform.position = point;
        }
    }
}