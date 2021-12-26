using System;
using System.Collections.Generic;
using System.Linq;
using DroneBase.Interfaces;

namespace DroneBase.Services
{
    public sealed class SelectionService : ISelectionService
    {
        public event Action<ISelectable> Selected;
        
        private List<ISelectable> _selectables = new List<ISelectable>();

        public void RegisterObject(ISelectable selectable)
        {
            selectable.Selected += OnSelected;
            _selectables.Add(selectable);
        }

        public void UnRegisterObject(ISelectable selectable)
        {
            selectable.Selected -= OnSelected;
            _selectables.Remove(selectable);
        }

        public IEnumerable<ISelectable> GetObjectByPredicate(Func<ISelectable, bool> predicate)
        {
            return _selectables.Where(predicate);
        }

        public bool TryGetObject(out ISelectable selectable)
        {
            selectable = _selectables.FirstOrDefault();
            return selectable != null;
        }
        
        public void ClearAllSelection()
        {
            foreach (var selectable in _selectables)
            {
                selectable.ClearSelection();
            }
        }

        private void OnSelected(ISelectable selectable)
        {
            Selected?.Invoke(selectable);
        }
    }
}