using System.Collections.Generic;
using System.Linq;
using Assets.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UI
{
    public class ContextMenuHandler : MonoBehaviour, IPointerDownHandler
    {
        private LinkedList<IContextActionSubscriber> _subscribers;

        private void Awake()
        {
            _subscribers = new LinkedList<IContextActionSubscriber>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ExpandContextMenu();
            }
        }

        public void Subscribe(IContextActionSubscriber subscriber)
        {
            //TODO: implement display priority
            _subscribers.AddLast(subscriber);
        }

        public void Unsubscribe(IContextActionSubscriber subscriber)
        {
            //TODO: implement display priority
            _subscribers.Remove(subscriber);
        }

        private void ExpandContextMenu()
        {
            var contextMenu = UIManager.Instance.GetContextMenu();

            foreach (var subscription in GetActiveSubscriptions())
            {
                contextMenu.SetContextAction(subscription);
            }

            contextMenu.Display(Input.mousePosition);
        }

        protected IEnumerable<IContextActionSubscriber> GetActiveSubscriptions()
        {
            var activeSubscribers = _subscribers.Where(x => x.ShowInContextMenu);

            return activeSubscribers;
        }
    }
}
