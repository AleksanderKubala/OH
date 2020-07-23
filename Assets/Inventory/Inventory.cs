using System;
using System.Collections.Generic;
using System.Linq;
using Assets.GameEntity;

namespace Assets.Inventory
{
    public class Inventory : IInventory
    {
        private readonly Dictionary<IInventorySpaceProvider, IInventorySpace> _inventorySpaces;

        public Inventory(IGameEntity owningGameEntity)
        {
            OwningGameEntity = owningGameEntity ?? throw new ArgumentNullException(nameof(owningGameEntity));
            _inventorySpaces = new Dictionary<IInventorySpaceProvider, IInventorySpace>();
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

        public IEnumerable<IInventorySpace> GetInventorySpaces()
        {
            var allInventorySpaces = _inventorySpaces.Values.Select(x => x);

            return allInventorySpaces;
        }

        public IEnumerable<IInventorySpace> GetInventorySpaces(Func<IInventorySpace, bool> predicate)
        {
            var selectedInventorySpaces = _inventorySpaces.Values.Where(predicate);

            return selectedInventorySpaces;
        }

        public bool GetInventorySpaceByProvider(IInventorySpaceProvider inventorySpaceProvider, out IInventorySpace inventorySpace)
        {
            var retrievedInventorySpace = _inventorySpaces.TryGetValue(inventorySpaceProvider, out inventorySpace);

            return retrievedInventorySpace;
        }
    }
}
