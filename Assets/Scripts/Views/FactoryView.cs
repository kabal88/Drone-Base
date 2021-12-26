using System;
using DroneBase.Enums;
using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Views
{
    public class FactoryView: MonoBehaviour, IFactoryView

    {
        public Transform Transform { get; }
        public EntityType Type { get; }
        public event Action<ISelectable> Selected;
        public void SetSelection()
        {
            throw new NotImplementedException();
        }

        public void ClearSelection()
        {
            throw new NotImplementedException();
        }

        public event Action<ITargetable> Targeted;
    }
}