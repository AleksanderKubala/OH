using System;
using System.Collections.Generic;
using OHLogic.GameEntity;
using OHLogic.Items;

namespace OHLogic.Equipment
{

    public interface IEquipmentSlotProvider : IGameEntityOwnershipTransferable
    {
        IEnumerable<EquipmentSlot> GetEquipmentSlots();
    }
}
