using System;
using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionDrop : Interaction
    {
        [SerializeField]
        private InteractablePickupable _pickupable;

        public override void Perform(EntityController interactingEntity)
        {
            throw new NotImplementedException();
        }

        protected override void SetEffectiveByInteractableState()
        {
            
        }
    }
}
