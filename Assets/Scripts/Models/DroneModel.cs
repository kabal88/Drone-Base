using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public class DroneModel: IDroneModel
    {
        public float Speed { get; }
        public float RotationSpeed { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get;private set; }
        public Vector3[] Path { get;private set; }
        public Vector3 Target { get;private set; }
        public Quaternion Rotation { get;private set; }
        
        public DroneModel(float speed, float rotationSpeed)
        {
            Speed = speed;
            RotationSpeed = rotationSpeed;
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

        public void SetPath(Vector3[] path)
        {
            Path = path;
        }

        public void SetTarget(Vector3 target)
        {
            Target = target;
        }
    }
}