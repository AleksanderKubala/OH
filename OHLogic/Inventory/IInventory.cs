using System;
using System.Collections.Generic;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Inventory
{
    public interface IInventory : IGameEntityOwned
    {
        IEnumerable<IInventorySpace> GetInventorySpaces(Func<IInventorySpace, bool> predicate);
        bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out IInventorySpace inventorySpace);
    }
}
