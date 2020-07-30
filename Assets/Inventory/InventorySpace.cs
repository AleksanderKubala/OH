using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.Items;

namespace Assets.Inventory
{
    public class InventorySpace : IInventorySpace
    {
        private readonly HashSet<IInteractable> _storedItems;

        public InventorySpace(string name, float capacity)
        {
            if(capacity <= 0.0f) { throw new ArgumentException($"{nameof(capacity)} must be positive"); }
            if(name == null) {  throw new ArgumentNullException(nameof(name)); }

            Name = name;
            MaximumSpace = capacity;
            TakenSpace = 0.0f;
            _storedItems = new HashSet<IInteractable>();
        }
        
        public float MaximumSpace { get; protected set; }
        public float TakenSpace { get; protected set; }
        public float SpaceLeft => MaximumSpace - TakenSpace;
        public string Name { get; private set; }

        public IEnumerable<IInteractable> GetAllItems()
        {
            var allItems = _storedItems.ToList();

            return allItems;
        }

        public IEnumerable<IInteractable> FilterItems(Func<IInteractable, bool> predicate)
        {
            var  selectedItems = _storedItems.Where(predicate);

            return selectedItems;
        }

        public bool HasEnoughSpace(IInteractable item)
        {
            return true;
        }

        public bool PutItemInside(IInteractable item)
        {
            var addedSuccessfully = _storedItems.Add(item);
            //TakenSpace += item.ItemData.Volume;

            return addedSuccessfully;
        }

        public bool TakeItemOut(IInteractable item)
        {
            var removedSuccessfully = _storedItems.Remove(item);
            //TakenSpace -= item.ItemData.Volume;

            return removedSuccessfully;
        }
    }
}
