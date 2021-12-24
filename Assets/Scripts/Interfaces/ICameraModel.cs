using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICameraModel : IMove, IRotate
    {
        float BoarderThickness { get; }
        float ScreenHeight { get; }
        float ScreenWight { get; }
        Vector2 MoveLimit { get; }
    }
}