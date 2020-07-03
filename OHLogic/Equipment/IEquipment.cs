using System;
using System.Collections.Generic;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Equipment
{
    public interface IEquipment : IGameEntityOwned
    {
        IEnumerable<EquipmentSlot> GetEquipmentSlots();
        IEnumerable<EquipmentSlot> GetEquipmentSlotsMatchingItem(IItem item);
    }
}
