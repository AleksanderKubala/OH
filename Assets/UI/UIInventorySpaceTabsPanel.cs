using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Inventory;
using Assets.Managers;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    //TODO: generalise UIInventorySpaceContentPanel, UIInventoryInteractionPanel, UIInventorySpaceTabPanel
    public class UIInventorySpaceTabsPanel : UIDynamicContentPanel<IInventorySpace, UIInventorySpaceTab>, IInventoryExpansionSubscriber, IInventoryShrinkageSubscriber
    {
        private IInventory _displayedInventory;
        private ToggleGroup _toggleGroup;

        protected override Transform UIElementParent => transform;

        private void Awake()
        {
            _toggleGroup = GetComponent<ToggleGroup>();
        }

        private void Start()
        {
            ResetDisplayedContents(GameManager.Player.Inventory);
        }

        public void ResetDisplayedContents(IInventory inventory)
        {
            SetUpInventoryReference(inventory);
            if (inventory.Count() > _uiElements.Count)
            {
                CreateMultipleUIElements(inventory.Count() - _uiElements.Count);
            }

            var itemsToDisplayIterator = inventory.GetEnumerator();
            for (int i = 0; i < _uiElements.Count; i++)
            {
                if (itemsToDisplayIterator.MoveNext())
                {
                    ResetUIElement(_uiElements[i], itemsToDisplayIterator.Current);
                    if(i == 0)
                    {
                        _uiElements[i].Toggle.isOn = true;
                    }
                }
                else
                {
                    ResetUIElement(_uiElements[i], null);
                }
            }
            RepositionUIElements(Comparer<UIInventorySpaceTab>.Default);
        }

        private void SetUpInventoryReference(IInventory inventory)
        {
            if (_displayedInventory != null)
            {
                _displayedInventory.InventoryExpanded -= OnInventoryExpanded;
                _displayedInventory.InventoryShrank -= OnInventoryShrank;
            }
            if (inventory != null)
            {
                inventory.InventoryExpanded += OnInventoryExpanded;
                inventory.InventoryShrank += OnInventoryShrank;
            }
            _displayedInventory = inventory;
        }

        public void OnInventoryShrank(object sender, IInventorySpace removedSpace)
        {
            RemoveContentFromUIElement(removedSpace);
            RepositionUIElements(Comparer<UIInventorySpaceTab>.Default);
        }

        public void OnInventoryExpanded(object sender, IInventorySpace newInventorySpace)
        {
            SetContentInUIElement(newInventorySpace);
            RepositionUIElements(Comparer<UIInventorySpaceTab>.Default);
        }

        protected override void ResetUIElement(UIInventorySpaceTab spaceTab, IInventorySpace inventorySpace)
        {
            spaceTab.Toggle.isOn = false;
            spaceTab.InventorySpaceToDisplay = inventorySpace;
        }

        protected override UIInventorySpaceTab GetUIElementWithContent(IInventorySpace inventorySpace)
        {
            return _uiElements.First(x => ReferenceEquals(x.InventorySpaceToDisplay, inventorySpace));
        }

        protected override bool IsUIElementUnused(UIInventorySpaceTab spaceTab)
        {
            return spaceTab.InventorySpaceToDisplay == null;
        }

        protected override UIInventorySpaceTab CreateUIElement()
        {
            var newTab = base.CreateUIElement();
            newTab.Toggle.group = _toggleGroup;
            _toggleGroup.RegisterToggle(newTab.Toggle);

            return newTab;
        }
    }
}
