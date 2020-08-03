using System;
using System.Collections;
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

            Name = name ?? throw new ArgumentNullException(nameof(name));
            MaximumSpace = capacity;
            TakenSpace = 0.0f;
            _storedItems = new HashSet<IInteractable>();
        }

        public event EventHandler<IInteractable> ItemTakenOut;
        public event EventHandler<IInteractable> ItemPutInside;

        public float MaximumSpace { get; protected set; }
        public float TakenSpace { get; protected set; }
        public float SpaceLeft => MaximumSpace - TakenSpace;
        public string Name { get; private set; }

        public bool HasEnoughSpace(IInteractable item)
        {
            return true;
        }

        public bool PutItemInside(IInteractable item)
        {
            var addedSuccessfully = _storedItems.Add(item);
            //TakenSpace += item.ItemData.Volume;
            if(addedSuccessfully)
            {
                ItemPutInside?.Invoke(this, item);
            }

            return addedSuccessfully;
        }

        public bool TakeItemOut(IInteractable item)
        {
            var removedSuccessfully = _storedItems.Remove(item);
            //TakenSpace -= item.ItemData.Volume;
            if(removedSuccessfully)
            {
                ItemTakenOut?.Invoke(this, item);
            }

            return removedSuccessfully;
        }

        public IEnumerator<IInteractable> GetEnumerator()
        {
            return _storedItems.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
