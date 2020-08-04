using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interactables;

namespace Assets.Inventory.Events
{
    public class ItemAddedRemovedEventArgs : EventArgs
    {
        public ItemAddedRemovedEventArgs(IInventorySpace inventorySpace, IInteractable interactable)
        {
            InventorySpace = inventorySpace;
            Interactable = interactable;
        }

        public IInventorySpace InventorySpace { get; }
        public IInteractable Interactable { get; }
    }
}
