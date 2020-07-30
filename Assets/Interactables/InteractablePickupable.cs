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

        public override IInteractableObjectData InteractableData => throw new NotImplementedException();

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
