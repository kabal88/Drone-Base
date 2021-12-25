using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICameraModel : IMove, IRotate
    {
        float BoarderThickness { get; }
        float ScreenHeight { get; }
        float ScreenWight { get; }
        float ZoomInLimit { get; }
        float ZoomOutLimit { get; }
        float ZoomSpeed { get; }
        Vector2 MoveLimit { get; }
    }
}