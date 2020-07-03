using System;
using OHLogic.Body;
using OHLogic.Data;
using OHLogic.GameEntity;

namespace OHLogic.Items
{
    public class Item : TransferableOwnershipObject, IItem
    {
        public readonly IItemData _ItemData;

        public Item(IItemData itemData)
        {
            ItemData = itemData ?? throw new ArgumentNullException(nameof(itemData));
        }

        public IItemData ItemData { get; protected set; }
        public ItemType ItemType => ItemData.ItemType;
        public BodypartType RelevantBodypart => ItemData.RelevantBodypart;

        public bool CanBeDropped()
        {
            return true;
        }

        public bool CanBeEquipped(Bodypart bodypartToEquipOn)
        {
            return true;
        }

        public bool CanBeTaken(IGameEntity takingGameEntity)
        {
            return true;
        }

        public bool CanBeUnequipped()
        {
            return true;
        }

        public void WhenDropped()
        {

        }

        public void WhenEquipped()
        {

        }

        public void WhenTaken()
        {

        }

        public void WhenUnequipped()
        {

        }
    }
}
