using System;
using System.Collections.Generic;
using OHLogic.Items;

namespace OHLogic.Inventory
{
    public interface IInventorySpace
    {
        IEnumerable<IItem> GetAllItems();
        IEnumerable<IItem> FilterItems(Func<IItem, bool> predicate);
        bool HasEnoughSpace(IItem item);
        bool PutItemInside(IItem item);
        bool TakeItemOut(IItem item);
    }
}
