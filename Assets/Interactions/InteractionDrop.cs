using System;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionDrop : Interaction
    {
        [SerializeField]
        private InteractablePickupable _pickupable;

        protected override InteractableObject AssociatedInteractable => _pickupable;

        public override void Perform(EntityController interactingEntity)
        {
            throw new NotImplementedException();
        }
    }
}
