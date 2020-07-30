using System;
using System.Collections.Generic;
using Assets.GameEntity;
using Assets.Interactables;

namespace Assets.Inventory
{
    public interface IInventory : IGameEntityOwned
    {
        IEnumerable<IInventorySpace> GetInventorySpaces(Func<IInventorySpace, bool> predicate);
        bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out IInventorySpace inventorySpace);
        bool RemoveItem(IInteractable item);
    }
}
