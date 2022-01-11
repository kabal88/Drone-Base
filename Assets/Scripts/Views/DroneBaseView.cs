using System;
using DroneBase.Animations;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Managers;
using UnityEngine;

namespace DroneBase.Views
{
    public class DroneBaseView : MonoBehaviour, IDroneBaseView
    {
        public event Action Selected;

        [SerializeField] private SelectSpriteAnimator _selectAnimator;
        [SerializeField] private Animator _gateAnimator;
        [SerializeField] private ActionArea _actionArea;
        
        private IDroneBaseModel _model;
        private IDroneBaseController _controller;

        public int Id => _model.Id;
        public Vector3 InteractivePoint => _actionArea.InteractivePoint;
        public Transform Transform => transform;
        public EntityType Type => _model.Type;
        public ITarget GetTarget => _controller;


        public void Init(IDroneBaseController controller, IDroneBaseModel model)
        {
            _model = model;
            _controller = controller;
            _actionArea.SetView(this);
        }

        public void SetGate(bool isOpen)
        {
            _gateAnimator.SetBool(AnimatorTagManager.IsOpen, isOpen);
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

        public void SetInteractivePoint(Vector3 point)
        {
            _actionArea.SetInteractivePoint(point);
        }
    }
}