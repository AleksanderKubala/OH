using System;
using System.Collections.Generic;
using Assets.Common;
using Assets.Interactables;
using Assets.Inventory.Events;
using Assets.Items;

namespace Assets.Inventory
{
    public interface IInventorySpace : INamedEntity, IEnumerable<IInteractable>
    {
        event EventHandler<ItemAddedRemovedEventArgs> ItemTakenOut;
        event EventHandler<ItemAddedRemovedEventArgs> ItemPutInside;

        bool HasEnoughSpace(IInteractable item);
        bool PutItemInside(IInteractable item);
        bool TakeItemOut(IInteractable item);
    }
}
