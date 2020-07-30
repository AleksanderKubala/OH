using System;
using System.Collections.Generic;
using Assets.Common;
using Assets.Interactables;
using Assets.Items;

namespace Assets.Inventory
{
    public interface IInventorySpace : INamedObject
    {
        IEnumerable<IInteractable> GetAllItems();
        IEnumerable<IInteractable> FilterItems(Func<IInteractable, bool> predicate);
        bool HasEnoughSpace(IInteractable item);
        bool PutItemInside(IInteractable item);
        bool TakeItemOut(IInteractable item);
    }
}
