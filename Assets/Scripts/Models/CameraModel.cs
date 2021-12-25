using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public sealed class CameraModel : ICameraModel
    {
        public float Speed { get; }
        public float RotationSpeed { get; }
        public float BoarderThickness { get; }
        public float ScreenHeight { get; }
        public float ScreenWight { get; }
        public float ZoomInLimit { get; }
        public float ZoomOutLimit { get; }
        public float ZoomSpeed { get; }
        public Vector2 MoveLimit { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public Quaternion Rotation { get; private set; }


        public CameraModel(MoveData moveData, RotationData rotationData, float boarderThickness, Vector2 moveLimit, ZoomData zoomData)
        {
            BoarderThickness = boarderThickness;
            MoveLimit = moveLimit;
            Position = moveData.Position;
            RotationSpeed = rotationData.RotationSpeed;
            Speed = moveData.Speed;
            Rotation = Quaternion.Euler(rotationData.Rotation);
            ScreenHeight = Screen.height;
            ScreenWight = Screen.width;
            ZoomInLimit = zoomData.ZoomInLimit;
            ZoomOutLimit = zoomData.ZoomOutLimit;
            ZoomSpeed = zoomData.ZoomSpeed;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }
    }
}