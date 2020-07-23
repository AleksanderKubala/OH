using System;
using Assets.Body;
using Assets.GameEntity;
using Assets.Items;

namespace Assets.Equipment
{
    public class EquipmentSlot : IEquipmentSlot
    {
        public EquipmentSlot(Bodypart associatedBodypart, ItemType requiredItemType)
        {
            RequiredItemType = requiredItemType ?? throw new ArgumentNullException(nameof(requiredItemType));
            AssociatedBodypart = associatedBodypart ?? throw new ArgumentNullException(nameof(associatedBodypart));
        }

        public event EventHandler ItemAssignedToSlot;
        public event EventHandler ItemUnassgignedFromSlot;

        public Bodypart AssociatedBodypart { get; protected set; }
        public ItemType RequiredItemType { get; protected set; }
        public IGameEntity OwningGameEntity => AssociatedBodypart.OwningGameEntity;
        public IItem EquippedItem { get; protected set; }

        public virtual bool IsOccupied()
        {
            return EquippedItem != null;
        }

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public bool AssignItem(IItem itemToEquip)
        {
            if(itemToEquip == null) { throw new ArgumentNullException(nameof(itemToEquip)); }

            var successfullyEquipped = false;

            if (UnassignCurrentItem() && CanEquip(itemToEquip) && itemToEquip.CanBeEquipped(AssociatedBodypart))
            {
                AssignNewItemToSlot(itemToEquip);
                if (!ReferenceEquals(itemToEquip.OwningGameEntity, this.OwningGameEntity))
                {
                    itemToEquip.TransferOwnership(this.OwningGameEntity);
                }
                itemToEquip.WhenEquipped();
                successfullyEquipped = true;
                //TODO: Set proper event arguments
                ItemAssignedToSlot?.Invoke(this, null);
            }

            return successfullyEquipped;
        }

        public bool UnassignCurrentItem()
        {
            var successfullyUnequipped = true;

            if(IsOccupied() && !EquippedItem.CanBeUnequipped())
            {
                successfullyUnequipped = false;
            }
            else
            {
                var previouslyEquipped = AssignNewItemToSlot(null);
                EquippedItem.WhenUnequipped();
                //TODO: set proper event arguments
                ItemUnassgignedFromSlot?.Invoke(this, null);
            }

            return successfullyUnequipped;
        }

        protected IEquipable AssignNewItemToSlot(IItem item)
        {
            var previouslyEquipped = EquippedItem;
            EquippedItem = item;

            return previouslyEquipped;
        }

        protected bool CanEquip(IItem itemToEquip)
        {
            //TODO: After goruping implementation is solved, check by groups and/or type
            var canEquip = 
                AssociatedBodypart.BodypartData.BodypartType.Equals(itemToEquip.ItemData.RelevantBodypart)
                && RequiredItemType.Equals(itemToEquip.ItemData.ItemType);

            return canEquip;
        }
    }
}
