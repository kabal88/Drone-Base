using DroneBase.Descriptions;
using UnityEngine;

namespace DroneBase.DescriptionContainers
{
    [CreateAssetMenu(fileName = "DroneDescription", menuName = "Descriptions/DroneDescription", order = 0)]
    public sealed class DroneDescriptionContainer : DescriptionContainer<DroneDescription>
    {
    }
}