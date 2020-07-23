using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Items;

namespace Assets.Inventory
{
    public class InventorySpace : IInventorySpace
    {
        private readonly HashSet<IItem> _storedItems;

        public InventorySpace(float capacity)
        {
            if(capacity <= 0.0f) { throw new ArgumentException($"{nameof(capacity)} must be positive"); }

            MaximumSpace = capacity;
            TakenSpace = 0.0f;
            _storedItems = new HashSet<IItem>();
        }
        
        public float MaximumSpace { get; protected set; }
        public float TakenSpace { get; protected set; }
        public float SpaceLeft => MaximumSpace - TakenSpace;

        public IEnumerable<IItem> GetAllItems()
        {
            var allItems = _storedItems.ToList();

            return allItems;
        }

        public IEnumerable<IItem> FilterItems(Func<IItem, bool> predicate)
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
            TakenSpace += item.ItemData.Volume;

            return addedSuccessfully;
        }

        public bool TakeItemOut(IItem item)
        {
            var removedSuccessfully = _storedItems.Remove(item);
            TakenSpace -= item.ItemData.Volume;

            return removedSuccessfully;
        }
    }
}
