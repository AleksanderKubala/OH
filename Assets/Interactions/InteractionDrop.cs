using System;
using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Common;
using Assets.Interactables;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Interactions
{
    public class InteractionDrop : Interaction
    {
        [SerializeField]
        private Interactable _interactable;

        protected override Interactable AssociatedInteractable => _interactable;

        public override void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments)
        {
            if (IsEffective)
            {
                var successfullyDropped = interactingEntity.Inventory.RemoveItem(AssociatedInteractable);
                if (successfullyDropped)
                {
                    //TODO: implement some way to determine where gameObject can be dropped considering obstacles in vicinity of entity
                    AssociatedInteractable.transform.position = interactingEntity.transform.position + interactingEntity.transform.forward;
                    AssociatedInteractable.RemoveState(InteractablesStates.InInventory);
                    AssociatedInteractable.gameObject.SetActive(true);
                }
            }
        }

        public override Transform GetInteractionSource()
        {
            return null;
        }

        protected override void OnInteractableStateChanged()
        {
            IsEffective = AssociatedInteractable.IsInState(InteractablesStates.InInventory);
        }
    }
}
