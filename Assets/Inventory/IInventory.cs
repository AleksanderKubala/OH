using System;
using System.Collections.Generic;
using Assets.GameEntity;

namespace Assets.Inventory
{
    public interface IInventory : IGameEntityOwned
    {
        IEnumerable<IInventorySpace> GetInventorySpaces(Func<IInventorySpace, bool> predicate);
        bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out IInventorySpace inventorySpace);
    }
}
