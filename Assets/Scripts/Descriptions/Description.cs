using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Descriptions
{
    public abstract class Description: ScriptableObject
    {
        public abstract IDescription GetDescription { get; }
    }
}