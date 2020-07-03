using System;
using System.Collections.Generic;
using System.Linq;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Inventory
{
    public abstract class Inventory : IInventory
    {
        private readonly Dictionary<IInventorySpaceProvider, InventorySpace> _inventorySpaces;

        public Inventory(IGameEntity owningGameEntity)
        {
            OwningGameEntity = owningGameEntity ?? throw new ArgumentNullException(nameof(owningGameEntity));
            _inventorySpaces = new Dictionary<IInventorySpaceProvider, InventorySpace>();
        }

        public IGameEntity OwningGameEntity { get; }

        public void Expand(IInventorySpaceProvider inventorySpaceProvider)
        {
            _inventorySpaces[inventorySpaceProvider] = inventorySpaceProvider.GetInventorySpace();
        }

        public void Shrink(IInventorySpaceProvider inventorySpaceProvider)
        {
            _inventorySpaces.Remove(inventorySpaceProvider);
        }

        public IEnumerable<InventorySpace> GetInventorySpaces()
        {
            var allInventorySpaces = _inventorySpaces.Values.Select(x => x);

            return allInventorySpaces;
        }

        public IEnumerable<InventorySpace> GetInventorySpaces(Func<InventorySpace, bool> predicate)
        {
            var selectedInventorySpaces = _inventorySpaces.Values.Where(predicate);

            return selectedInventorySpaces;
        }

        public bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out InventorySpace inventorySpace)
        {
            var retrievedInventorySpace = _inventorySpaces.TryGetValue(inventorySpaceProvider, out inventorySpace);

            return retrievedInventorySpace;
        }
    }
}
