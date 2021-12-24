using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Descriptions
{
    public class DescriptionContainer<T> : Description where T : IDescription
    {
        [SerializeField] private T description;

        public override IDescription GetDescription => description;
    }
}