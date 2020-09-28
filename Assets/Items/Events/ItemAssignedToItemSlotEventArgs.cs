using System;
using Assets.Body;

namespace Assets.Items.Events
{
    public class ItemAssignedToItemSlotEventArgs : EventArgs
    {
        public ItemAssignedToItemSlotEventArgs(IItem assignedItem, IBodypart bodypartContainingSlot)
        {
            AssignedItem = assignedItem;
            BodypartContainingSlot = bodypartContainingSlot;
        }

        public IItem AssignedItem { get; protected set; }
        public IBodypart BodypartContainingSlot { get; protected set; }
    }
}
