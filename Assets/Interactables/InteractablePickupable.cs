using System;
using Assets.Data;
using Assets.Items;
using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public class InteractablePickupable : InteractableObject
    {
        [SerializeField]
        private ItemData _itemData;

        public IItemData ItemData => (Item != null) ? Item.ItemData : _itemData;
        public IItem Item { get; set; }

        private void Awake()
        {
            //if (ItemData == null) { throw new Exception($"Item \"{gameObject.name}\" uninitialized"); }
            //if (Item == null)
            //{
            //    Item = _itemData.CreateItemInstance();
            //}
        }
    }
}
