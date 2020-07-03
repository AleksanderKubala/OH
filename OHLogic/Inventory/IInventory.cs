using System;
using System.Collections.Generic;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Inventory
{
    public interface IInventory : IGameEntityOwned
    {
        IEnumerable<InventorySpace> GetInventorySpaces(Func<InventorySpace, bool> predicate);
        bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out InventorySpace inventorySpace);
    }
}
