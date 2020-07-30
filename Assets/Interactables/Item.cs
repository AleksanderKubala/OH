using Assets.Body;
using Assets.Data;
using Assets.GameEntity;
using Assets.Items;

namespace Assets.Interactables
{
    public class Item : InteractablePickupable, IItem
    {
        public ItemType ItemType => throw new System.NotImplementedException();
        public BodypartType RelevantBodypart => throw new System.NotImplementedException();
        public IGameEntity OwningGameEntity => throw new System.NotImplementedException();

        public IItemData ItemData => throw new System.NotImplementedException();

        public bool CanBeDropped()
        {
            throw new System.NotImplementedException();
        }

        public bool CanBeEquipped(Bodypart bodypartToEquipOn)
        {
            throw new System.NotImplementedException();
        }

        public bool CanBeTaken(IGameEntity takingGameEntity)
        {
            throw new System.NotImplementedException();
        }

        public bool CanBeUnequipped()
        {
            throw new System.NotImplementedException();
        }

        public void TransferOwnership(IGameEntity newOwner)
        {
            throw new System.NotImplementedException();
        }

        public void WhenDropped()
        {
            throw new System.NotImplementedException();
        }

        public void WhenEquipped()
        {
            throw new System.NotImplementedException();
        }

        public void WhenTaken()
        {
            throw new System.NotImplementedException();
        }

        public void WhenUnequipped()
        {
            throw new System.NotImplementedException();
        }
    }
}
