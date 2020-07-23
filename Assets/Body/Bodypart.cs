using System;
using System.Linq;
using System.Collections.Generic;
using Assets.GameEntity;
using Assets.Equipment;
using Assets.Data;

namespace Assets.Body
{
    public class Bodypart : TransferableOwnershipObject, IBodypart
    {
        protected HashSet<EquipmentSlot> _equipmentSlots;

        public Bodypart(IBodypartData bodypartData,  HashSet<EquipmentSlot> itemSlots)
        {
            _equipmentSlots = itemSlots ?? throw new ArgumentNullException(nameof(itemSlots));
            BodypartData = bodypartData ?? throw new ArgumentNullException(nameof(bodypartData));
            if(bodypartData.BodypartType == BodypartTypes.None) { throw new ArgumentException($"Bodypart cannot be type {BodypartTypes.None.Name}"); }

            Health = BodypartData.MaximumHealth;
        }

        public event EventHandler<float> BodypartDamageChanged;

        public float Health { get; set; }
        public IBodypartData BodypartData { get; protected set; }

        public void ReceiveDamage(float damage)
        {
            Health -= damage;
            if (Health < 0.0f)
            {
                Health = 0.0f;
            }
            BodypartDamageChanged?.Invoke(this, damage);
        }

        public IEnumerable<EquipmentSlot> GetEquipmentSlots()
        {
            var equipmentSlots = _equipmentSlots.Select(x => x);

            return equipmentSlots;
        }
    }
}
