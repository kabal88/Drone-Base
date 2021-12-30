using DroneBase.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DroneBase.Descriptions
{
    public class DescriptionContainer<T> : Description where T : IDescription
    {
        [SerializeField, HideLabel] private T description;

        public override IDescription GetDescription => description;
    }
}