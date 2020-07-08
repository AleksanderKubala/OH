using System;
using System.Collections.Generic;
using System.Linq;
using OHLogic.Items;

namespace OHLogic.Inventory
{
    public class InventorySpace : IInventorySpace
    {
        private readonly HashSet<IItem> _storedItems;

        public InventorySpace(float capacity)
        {
            if(capacity <= 0.0f) { throw new ArgumentException($"{nameof(capacity)} must be positive"); }

            Capacity = capacity;
            _storedItems = new HashSet<IItem>();
        }
        
        public float Capacity {  get; protected set; }

        public IEnumerable<IItem> GetStoredItems()
        {
            var allItems = _storedItems.Select(x => x);

            return allItems;
        }

        public IEnumerable<IItem> GetStoredItems(Func<IItem, bool> predicate)
        {
            var  selectedItems = _storedItems.Where(predicate);

            return selectedItems;
        }

        public bool HasEnoughSpace(IItem item)
        {
            return true;
        }

        public bool PutItemInside(IItem item)
        {
            var addedSuccessfully = _storedItems.Add(item);

            return addedSuccessfully;
        }

        public bool TakeItemOut(IItem item)
        {
            var removedSuccessfully = _storedItems.Remove(item);

            return removedSuccessfully;
        }
    }
}
