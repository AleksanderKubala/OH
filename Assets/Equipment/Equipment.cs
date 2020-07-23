using System;
using System.Collections.Generic;
using System.Linq;
using Assets.GameEntity;
using Assets.Items;

namespace Assets.Equipment
{
    public class Equipment : IEquipment
    {
        private readonly HashSet<EquipmentSlot> _equipmentSlots;

        public Equipment(IGameEntity owningGameEntity)
        {
            OwningGameEntity = owningGameEntity ?? throw new ArgumentNullException(nameof(owningGameEntity));
            _equipmentSlots = new HashSet<EquipmentSlot>();
        }

        public IGameEntity OwningGameEntity { get; }

        public IEnumerable<EquipmentSlot> GetEquipmentSlots(Func<EquipmentSlot, bool> predicate)
        {
            var retrievedEquipmentSlots = _equipmentSlots.Where(predicate);

            return retrievedEquipmentSlots;
        }

        public IEnumerable<EquipmentSlot> GetEquipmentSlots()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentSlot> GetEquipmentSlotsMatchingItem(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}
