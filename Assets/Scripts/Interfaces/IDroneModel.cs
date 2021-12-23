using UnityEngine;

namespace DroneBase.Interfaces
{
    public interface IDroneModel: IMove, IRotate, INavigate
    {
        
    }

    public interface INavigate
    {
        Vector3[] Path { get; }
        Vector3 Target { get; }

        void SetPath(Vector3[] path);
        void SetTarget(Vector3 target);
    }
}