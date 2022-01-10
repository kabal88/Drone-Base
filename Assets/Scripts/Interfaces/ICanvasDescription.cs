using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface ICanvasDescription : IDescription
    {
        GameObject Prefab { get; }
        
        ICanvasModel Model { get; }
    }
}