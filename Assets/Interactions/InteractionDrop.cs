using System;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Interactions
{
    public class InteractionDrop : Interaction
    {
        [SerializeField]
        private InteractablePickupable _pickupable;
        [SerializeField]
        private InteractableState _removedState;

        public override Transform InteractionSource => _pickupable.transform;
        protected override InteractableObject AssociatedInteractable => _pickupable;

        public override void Perform(EntityController interactingEntity)
        {
            var successfullyDropped = interactingEntity.Inventory.RemoveItem(_pickupable.Item);
            if(successfullyDropped)
            {
                //TODO: implement someway to determine where gameObject can be dropped considering obstacles in vicinity of entity
                _pickupable.transform.position = interactingEntity.transform.position + interactingEntity.transform.forward;
                _pickupable.RemoveState(_removedState);
                _pickupable.gameObject.SetActive(true);
            }
        }
    }
}
