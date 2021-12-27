using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Data
{
    public struct CustomRaycastHit
    {
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
            
            if (hit.collider.TryGetComponent<ISelectable>(out var selectable))
            {
                Selectable = selectable;
                Type = selectable.Type;
            }
            
            if (hit.collider.TryGetComponent<ITargetable>(out var target))
            {
                Targetable = target;
                Type = target.Type;
            }
        }
    }
}