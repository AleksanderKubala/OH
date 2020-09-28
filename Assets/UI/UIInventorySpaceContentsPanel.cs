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

        protected override Transform UIElementParent => _content.transform;

        private void Start()
        {
            if(_uiElements.Any())
            {
                foreach(var inventoryItemButton in _uiElements)
                {
                    InventoryItemButtonAdded?.Invoke(inventoryItemButton);
                } 
            }
        }

        public void ResetDisplayedContents(IEnumerable<IInteractable> itemsToDisplay)
        {
            if(itemsToDisplay.Count() > _uiElements.Count)
            {
                CreateMultipleUIElements(itemsToDisplay.Count() - _uiElements.Count);
            }

            var itemsToDisplayIterator = itemsToDisplay.GetEnumerator();
            foreach (var itemButton in _uiElements)
            {
                if (itemsToDisplayIterator.MoveNext())
                {
                    ResetUIElement(itemButton, itemsToDisplayIterator.Current);
                }
                else 
                {
                    ResetUIElement(itemButton, null);
                }
            }
            _unusedUIElementsSubListIndex = itemsToDisplay.Count();
            RepositionUIElements(Comparer<UIInventorySpaceContentsItem>.Default);
        }

        protected override void ResetUIElement(UIInventorySpaceContentsItem itemToggle, IInteractable interactable)
        {
            itemToggle.Toggled = false;
            itemToggle.Interactable = interactable;
        }

        protected override UIInventorySpaceContentsItem GetUIElementWithContent(IInteractable interactable)
        {
            return _uiElements.First(x => ReferenceEquals(x.Interactable, interactable));
        }

        protected override bool IsUIElementUnused(UIInventorySpaceContentsItem itemToggle)
        {
            return itemToggle.Interactable == null;
        }

        protected override UIInventorySpaceContentsItem CreateUIElement()
        {
            var newItemButton = base.CreateUIElement();
            InventoryItemButtonAdded?.Invoke(newItemButton);

            return newItemButton;
        }
    }
}