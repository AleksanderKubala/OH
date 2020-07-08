using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Assets.Managers;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UI
{
    public class ContextMenuHandler : MonoBehaviour, IPointerDownHandler
    {
        private List<ContextActionSubscription> _gatheredSubscriptions;

        private void Awake()
        {
            _gatheredSubscriptions = new List<ContextActionSubscription>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ExpandContextMenu();
            }
        }

        public void Subscribe(ContextActionSubscription subscription)
        {
            _gatheredSubscriptions.Add(subscription);
            _gatheredSubscriptions.Sort((l, r) => l.Priority.CompareTo(r.Priority));
        }

        public void Unsunscribe(ContextActionSubscription subscription)
        {
            _gatheredSubscriptions.Remove(subscription);
            _gatheredSubscriptions.Sort((l, r) => l.Priority.CompareTo(r.Priority));
        }

        private void ExpandContextMenu()
        {
            var contextMenu = UIManager.Instance.GetContextMenu();
            
            foreach (var interaction in _gatheredSubscriptions)
            {
                contextMenu.AddContextAction(interaction);
            }

            contextMenu.Display(Input.mousePosition);
        }
    }
}
