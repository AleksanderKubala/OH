using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Inventory;
using Assets.Managers;
using UnityEngine;

namespace Assets.UI
{
    //TODO: generalise UIInventorySpaceContentPanel, UIInventoryInteractionPanel, UIInventorySpaceTabPanel
    public class UIInventorySpaceTabsPanel : UIDynamicContentPanel<IInventorySpace, UIInventorySpaceTab>, IInventoryExpansionSubscriber, IInventoryShrinkageSubscriber
    {
        private IInventory _displayedInventory;

        protected override Transform ContentsParent => transform;

        private void Start()
        {
            ResetDisplayedContents(GameManager.Player.Inventory);
        }

        public void ResetDisplayedContents(IInventory inventory)
        {
            SetUpInventoryReference(inventory);
            if (inventory.Count() > _contentElements.Count)
            {
                CreateMultipleUIContentElements(inventory.Count() - _contentElements.Count);
            }

            var itemsToDisplayIterator = inventory.GetEnumerator();
            for (int i = 0; i < _contentElements.Count; i++)
            {
                if (itemsToDisplayIterator.MoveNext())
                {
                    ResetContentElementButton(_contentElements[i], itemsToDisplayIterator.Current);
                }
                else
                {
                    ResetContentElementButton(_contentElements[i], null);
                }
            }
            RepositionElements(Comparer<UIInventorySpaceTab>.Default);
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
            RepositionElements(Comparer<UIInventorySpaceTab>.Default);
        }

        public void OnInventoryExpanded(object sender, IInventorySpace newInventorySpace)
        {
            AppendUIContentElement(newInventorySpace);
            RepositionElements(Comparer<UIInventorySpaceTab>.Default);
        }

        protected override void ResetContentElementButton(UIInventorySpaceTab spaceTab, IInventorySpace inventorySpace)
        {
            spaceTab.Toggled = false;
            spaceTab.InventorySpaceToDisplay = inventorySpace;
        }

        protected override UIInventorySpaceTab GetUIContentElementWithContent(IInventorySpace inventorySpace)
        {
            return _contentElements.First(x => ReferenceEquals(x.InventorySpaceToDisplay, inventorySpace));
        }

        protected override bool IsUIElementUnused(UIInventorySpaceTab spaceTab)
        {
            return spaceTab.InventorySpaceToDisplay == null;
        }
    }
}
