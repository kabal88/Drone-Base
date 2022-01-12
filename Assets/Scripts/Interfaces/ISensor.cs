using System;
using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ISensor
    {
        event Action<Collider> SensorEnterTrigger; //TODO: Нужно отвязаться от Unity и заменить Collider на собственную структуру
        event Action<Collider> SensorExitTrigger;
    }
}