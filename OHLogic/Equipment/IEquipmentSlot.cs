using System;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Equipment
{
    public interface IEquipmentSlot : IGameEntityOwned
    {
        IItem EquippedItem { get; }

        //bool CanEquip(IItem objectToEquip);
        bool AssignItem(IItem itemToEquip);
        bool UnassignCurrentItem();
        bool IsOccupied();
        bool IsAvailable();
    }
}
