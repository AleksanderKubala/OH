using System;
using Assets.Body;
using Assets.GameEntity;

namespace Assets.Items.Events
{
    public class ItemEquippedEventArgs : EventArgs
    {
        public ItemEquippedEventArgs(IItem equippedItem, IBodypart bodypartEquippedOn, IGameEntity owner)
        {
            EquippedItem = equippedItem;
            Owner = owner;
            BodypartEquippedOn = bodypartEquippedOn;
        }

        public IItem EquippedItem { get; protected set; }
        public IGameEntity Owner { get; protected set; }
        public IBodypart BodypartEquippedOn { get; protected set; }

    }
}
