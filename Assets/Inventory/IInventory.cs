using System;
using System.Collections.Generic;
using Assets.GameEntity;
using Assets.Interactables;

namespace Assets.Inventory
{
    public interface IInventory : IGameEntityOwned, IEnumerable<IInventorySpace>
    {
        event EventHandler<IInventorySpace> InventoryExpanded;
        event EventHandler<IInventorySpace> InventoryShrank;

        bool RemoveItem(IInteractable item);
        void Expand(IInventorySpace inventorySpace);
        void Shrink(IInventorySpace inventorySpace);
    }
}
