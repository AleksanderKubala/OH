using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.UI.Events;
using UnityEngine;

namespace Assets.UI
{
    //TODO: generalise UIInventorySpaceContentPanel, UIInventoryInteractionPanel, UIInventorySpaceTabPanel
    public class UIInventorySpaceContentsPanel : UIDynamicContentPanel<IInteractable, UIInventorySpaceContentsItem>
    {
        [SerializeField]
        private GameObject _content;

        [SerializeField]
        public InventoryItemButtonAddedEvent InventoryItemButtonAdded;

        protected override Transform ContentsParent => _content.transform;

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

        public void ResetDisplayedContents(IEnumerable<IInteractable> itemsToDisplay)
        {
            if(itemsToDisplay.Count() > _contentElements.Count)
            {
                CreateMultipleUIContentElements(itemsToDisplay.Count() - _contentElements.Count);
            }

            var itemsToDisplayIterator = itemsToDisplay.GetEnumerator();
            foreach (var itemButton in _contentElements)
            {
                if (itemsToDisplayIterator.MoveNext())
                {
                    ResetContentElementButton(itemButton, itemsToDisplayIterator.Current);
                }
                else 
                {
                    ResetContentElementButton(itemButton, null);
                }
            }
            _unusedElementsSubListIndex = itemsToDisplay.Count();
            RepositionElements(Comparer<UIInventorySpaceContentsItem>.Default);
        }

        protected override void ResetContentElementButton(UIInventorySpaceContentsItem itemToggle, IInteractable interactable)
        {
            itemToggle.Toggled = false;
            itemToggle.Interactable = interactable;
        }

        protected override UIInventorySpaceContentsItem GetUIContentElementWithContent(IInteractable interactable)
        {
            return _contentElements.First(x => ReferenceEquals(x.Interactable, interactable));
        }

        protected override bool IsUIElementUnused(UIInventorySpaceContentsItem itemToggle)
        {
            return itemToggle.Interactable == null;
        }

        protected override UIInventorySpaceContentsItem CreateContentUIElement()
        {
            var newItemButton = base.CreateContentUIElement();
            InventoryItemButtonAdded?.Invoke(newItemButton);

            return newItemButton;
        }
    }
}