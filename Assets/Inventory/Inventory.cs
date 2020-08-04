using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Assets.GameEntity;
using Assets.Interactables;
using Assets.Items;

namespace Assets.Inventory
{
    public class Inventory : IInventory
    {
        private readonly HashSet<IInventorySpace> _inventorySpaces;

        public Inventory(IGameEntity owningGameEntity)
        {
            OwningGameEntity = owningGameEntity ?? throw new ArgumentNullException(nameof(owningGameEntity));
            _inventorySpaces = new HashSet<IInventorySpace>();
        }

        public event EventHandler<IInventorySpace> InventoryExpanded;
        public event EventHandler<IInventorySpace> InventoryShrank;

        public IGameEntity OwningGameEntity { get; }

        public void Expand(IInventorySpace inventorySpace)
        {
            if (_inventorySpaces.Add(inventorySpace))
            {
                InventoryExpanded?.Invoke(this, inventorySpace);
            }

        }

        public void Expand(IEnumerable<IInventorySpace> inventorySpaces)
        {
            foreach(var space in inventorySpaces)
            {
                Expand(space);
            }
        }

        public void Shrink(IInventorySpace inventorySpace)
        {
            if (_inventorySpaces.Remove(inventorySpace))
            {
                InventoryShrank?.Invoke(this, inventorySpace);
            }
        }

        public void Shrink(IEnumerable<IInventorySpace> inventorySpaces)
        {
            foreach(var space in inventorySpaces)
            {
                Shrink(space);
            }
        }

        public bool RemoveItem(IInteractable item)
        {
            var inventorySpaceContainingItem = this.First(x => x.Contains(item));
            var successfullyRemoved = inventorySpaceContainingItem?.TakeItemOut(item) ?? false;

            return successfullyRemoved;
        }

        public IEnumerator<IInventorySpace> GetEnumerator()
        {
            return _inventorySpaces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
