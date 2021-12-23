using DroneBase.Data;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public class CameraModel : ICameraModel
    {
        public float Speed { get; }
        public float RotationSpeed { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public Quaternion Rotation { get; private set; }

        public CameraModel(MoveData moveData, RotationData rotationData)
        {
            Position = moveData.Position;
            RotationSpeed = rotationData.RotationSpeed;
            Speed = moveData.Speed;
            Rotation = Quaternion.Euler(rotationData.Rotation);
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