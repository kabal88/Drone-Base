using DroneBase.Identifier;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public sealed class SpawnPointView : MonoBehaviour, ISpawnPointView
    {
        [SerializeField] private IdentifierContainer _identifierContainer;
        public Transform Transform => transform;
        public int Id => _identifierContainer.Id;
    }
}