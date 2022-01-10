using System;
using UnityEngine;
using UnityEngine.UI;

namespace DroneBase.UI
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private Button _buttonComponent;

        private void OnEnable()
        {
            _buttonComponent.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            _buttonComponent.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            OnClick?.Invoke();
        }
    }
}
