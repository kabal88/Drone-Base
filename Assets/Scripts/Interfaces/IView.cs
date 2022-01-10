using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IView : IIdentifier
    {
        Transform Transform { get; }
    }
}