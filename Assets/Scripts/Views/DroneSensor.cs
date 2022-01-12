using System;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class DroneSensor : MonoBehaviour, ISensor
    {
        public event Action<Collider> SensorEnterTrigger;
        public event Action<Collider> SensorExitTrigger;

        public void OnTriggerEnter(Collider other)
        {
            SensorEnterTrigger?.Invoke(other);
        }

        public void OnTriggerExit(Collider other)
        {
            SensorExitTrigger?.Invoke(other);
        }
    }
}