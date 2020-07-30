using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.UI.Events;
using UnityEngine;

namespace Assets.UI
{
    public class UIInventorySpaceContentsPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventoryContentElementPrefab;
        [SerializeField]
        private GameObject _content;
        [SerializeField]
        private List<UIInventorySpaceContentsItem> _contentElements;

        [SerializeField]
        public InventoryItemButtonAddedEvent InventoryItemButtonAdded;

        private void Start()
        {
            if(_contentElements.Any())
            {
                foreach(var inventoryItemButton in _contentElements)
                {
                    InventoryItemButtonAdded?.Invoke(inventoryItemButton);
                } 
            }
        }

        public void ChangeDisplayedInventoryContents(IEnumerable<IInteractable> itemsToDisplay)
        {
            var itemsToDisplayCount = itemsToDisplay.Count();
            AdjustNumberOfUIContentElements(itemsToDisplayCount);
            //PrepareUIContentElements(itemsToDisplayCount);

            var itemsToDisplayIterator = itemsToDisplay.GetEnumerator();
            var contentElementsIterator = _contentElements.GetEnumerator();
            var done = false;
            while(contentElementsIterator.MoveNext() && !done)
            {
                if(itemsToDisplayIterator.MoveNext())
                {
                    contentElementsIterator.Current.Interactable = itemsToDisplayIterator.Current;
                }
                else if(contentElementsIterator.Current.gameObject.activeSelf)
                {
                    contentElementsIterator.Current.Interactable = null;
                }
                else
                {
                    done = true;
                }
            }
        }

        private void PrepareUIContentElements(int numberOfElementsToDisplay)
        {
            //var currentlyDisplayedContentElements = _contentElements.Count(x => x.gameObject.activeSelf);
            //var loopIteratorStep = Math.Sign(numberOfElementsToDisplay - currentlyDisplayedContentElements);
            //var 

            //for (int i = currentlyDisplayedContentElements; i != numberOfElementsToDisplay; i += loopIteratorStep)
            //{
            //    if(neededContentElementsDifference < 0)
            //    {
            //        //
            //    }
            //    if(neededContentElementsDifference > 0)
            //    {
            //        //
            //    }
            //}
        }

        private void AdjustNumberOfUIContentElements(int neededElements)
        {
            if(neededElements > _contentElements.Count)
            {
                _contentElements.Capacity = neededElements;
                for(int i = _contentElements.Count; i < _contentElements.Capacity; i++)
                {
                    _contentElements[i] = Instantiate(_inventoryContentElementPrefab, Vector3.zero, Quaternion.identity, _content.transform).GetComponent<UIInventorySpaceContentsItem>();
                    InventoryItemButtonAdded?.Invoke(_contentElements[i]);
                }
            }
        }
    }
}