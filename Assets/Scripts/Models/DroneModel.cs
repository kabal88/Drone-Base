using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Models
{
    public class DroneModel: IDroneModel
    {
        public float Speed { get; }
        public float RotationSpeed { get; }
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
        public Quaternion Rotataion { get; }
        
        public void SetPosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public void SetDirection(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void SetRotation(Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }
    }
}