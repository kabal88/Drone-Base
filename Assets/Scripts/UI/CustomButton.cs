using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DroneBase.UI
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private Button _buttonComponent;
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private List<Image> _warningImages;
        [Title("Alarm On")]
        [SerializeField] private Color _onColor;
        [SerializeField] private string _onText;
        [Title("Alarm Off")]
        [SerializeField] private Color _offColor;
        [SerializeField] private string _offText;

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

        public void SetButtonPress(bool isPressed)
        {
            if (isPressed)
            {
                _buttonComponent.image.color = _onColor;
                _buttonText.text = _onText;
            }
            else
            {
                _buttonComponent.image.color = _offColor;
                _buttonText.text = _offText;
            }

            foreach (var image in _warningImages)
            {
                image.enabled = isPressed;
            }
        }
    }
}
