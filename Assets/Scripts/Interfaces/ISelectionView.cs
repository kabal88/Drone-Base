using System;

namespace DroneBase.Interfaces
{
    public interface ISelectionView
    {
        event Action Selected;
        void PlaySelectionAnimation();
        void StopSelectionAnimation();
    }
}