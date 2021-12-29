using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Data
{
    public readonly struct CustomRaycastHit
    {
        public bool HasTargetable { get; }
        public bool HasSelectable { get; }
        public Vector3 Point { get; }
        public EntityType Type { get; }
        public ITargetable Targetable { get; }
        public ISelectable Selectable { get; }

        public CustomRaycastHit(RaycastHit hit)
        {
            Point = hit.point;
            Type = EntityType.None;
            Targetable = null;
            Selectable = null;

            HasSelectable = hit.collider.TryGetComponent<ISelectable>(out var selectable);
            if (HasSelectable)
            {
                Selectable = selectable;
                Type = selectable.Type;
            }

            HasTargetable = hit.collider.TryGetComponent<ITargetable>(out var target);
            if (HasTargetable)
            {
                Targetable = target;
                Type = target.Type;
            }
        }
    }
}