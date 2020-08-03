using System;
using System.Collections.Generic;
using Assets.Common;
using Assets.Interactables;
using Assets.Items;

namespace Assets.Inventory
{
    public interface IInventorySpace : INamedObject, IEnumerable<IInteractable>
    {
        event EventHandler<IInteractable> ItemTakenOut;
        event EventHandler<IInteractable> ItemPutInside;

        bool HasEnoughSpace(IInteractable item);
        bool PutItemInside(IInteractable item);
        bool TakeItemOut(IInteractable item);
    }
}
