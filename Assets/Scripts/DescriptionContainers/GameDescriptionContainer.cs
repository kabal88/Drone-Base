using DroneBase.Descriptions;
using UnityEngine;

namespace DroneBase.DescriptionContainers
{
    [CreateAssetMenu(fileName = "GameDescription", menuName = "Descriptions/GameDescription", order = 0)]
    public sealed class GameDescriptionContainer : DescriptionContainer<GameDescription>
    {
    }
}