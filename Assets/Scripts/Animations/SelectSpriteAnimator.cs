using DG.Tweening;
using DroneBase.Tweens;
using UnityEngine;

namespace DroneBase.Animations
{
    public class SelectSpriteAnimator : MonoBehaviour
    {
        [SerializeField] private ScaleParams _scaleParams;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void ShowSelectedAnimation()
        {
            _spriteRenderer.enabled = true;
            transform.localScale =
                new Vector3(_scaleParams.StartScale, _scaleParams.StartScale, _scaleParams.StartScale);
            transform.DOScale(_scaleParams.Target, _scaleParams.Duration);
        }

        public void HideSelectAnimation()
        {
            _spriteRenderer.enabled = false;
        }
    }
}