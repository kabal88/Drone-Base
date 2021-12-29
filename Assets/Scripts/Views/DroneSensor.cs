using System;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class DroneSensor : MonoBehaviour, ISensor
    {
        public event Action<Collider> SensorCollide;

        public void OnTriggerEnter(Collider other)
        {
            SensorCollide?.Invoke(other);
        }
    }
}