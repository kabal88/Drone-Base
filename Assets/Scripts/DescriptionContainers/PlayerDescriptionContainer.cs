using DroneBase.Descriptions;
using UnityEngine;

namespace DroneBase.DescriptionContainers
{
    [CreateAssetMenu(fileName = "PlayerDescription", menuName = "Descriptions/PlayerDescription", order = 0)]
    public sealed class PlayerDescriptionContainer : DescriptionContainer<PlayerDescription>
    {
    }
}