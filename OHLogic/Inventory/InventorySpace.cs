using System;
using System.Collections.Generic;
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


        public bool ContainsItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IItem> GetStoredItems(Func<bool, IItem> predicate)
        {
            throw new NotImplementedException();
        }

        public bool HasEnoughSpace(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public bool PutItemInside(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public bool TakeItemOut(IItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
