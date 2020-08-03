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
        [SerializeField]
        private InteractableObjectData _interactableData;

        public override IInteractableObjectData InteractableData => _interactableData;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
