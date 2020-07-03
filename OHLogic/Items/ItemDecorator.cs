using OHLogic.Body;
using OHLogic.Data;
using OHLogic.Equipment;
using OHLogic.GameEntity;
using OHLogic.Items.Events;

namespace OHLogic.Items
{
    public abstract class ItemDecorator : IItem
    {
        private readonly IItem _decoratedItem;

        public ItemDecorator(IItem decoratedItem)
        {
            _decoratedItem = decoratedItem;
        }

        public IGameEntity OwningGameEntity => _decoratedItem.OwningGameEntity;
        public IItemData ItemData => _decoratedItem.ItemData;
        public ItemType ItemType => _decoratedItem.ItemData.ItemType;
        public BodypartType RelevantBodypart => _decoratedItem.ItemData.RelevantBodypart;

        public virtual bool CanBeDropped()
        {
            return _decoratedItem.CanBeDropped();
        }

        public virtual bool CanBeEquipped(Bodypart bodypartToEquipOn)
        {
            return _decoratedItem.CanBeEquipped(bodypartToEquipOn);
        }

        public virtual bool CanBeTaken(IGameEntity takingGameEntity)
        {
            return _decoratedItem.CanBeTaken(takingGameEntity);
        }

        public virtual bool CanBeUnequipped()
        {
            return _decoratedItem.CanBeUnequipped();
        }

        public void TransferOwnership(IGameEntity newOwner)
        {
            _decoratedItem.TransferOwnership(newOwner);
        }

        public virtual void WhenDropped()
        {
            _decoratedItem.WhenDropped();
        }

        public virtual void WhenEquipped()
        {
            _decoratedItem.WhenEquipped();
        }

        public virtual void WhenTaken()
        {
            _decoratedItem.WhenTaken();
        }

        public virtual void WhenUnequipped()
        {
            _decoratedItem.WhenUnequipped();
        }
    }
}
