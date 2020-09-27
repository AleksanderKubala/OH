using System.Collections.Generic;
using System.Linq;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionPutIntoInventory : Interaction
    {
        [SerializeField]
        private Interactable _interactable;

        protected override Interactable AssociatedInteractable => _interactable;

        public override void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments)
        {
            if (IsEffective)
            {
                var availableSpaces = interactingEntity.Inventory.Where(x => x.HasEnoughSpace(AssociatedInteractable));
                if (availableSpaces.Any())
                {
                    //TODO: recode properly to go thorugh available spaces and select the best fitting one
                    var isPlacedInInventory = availableSpaces.First().PutItemInside(AssociatedInteractable);
                    if (isPlacedInInventory)
                    {
                        AssociatedInteractable.AddState(InteractablesStates.InInventory);
                        AssociatedInteractable.gameObject.SetActive(false);
                    }
                }
            }
        }

        public override Transform GetInteractionSource()
        {
            return AssociatedInteractable.transform;
        }

        protected override void OnInteractableStateChanged()
        {
            IsEffective = AssociatedInteractable.IsInState(InteractablesStates.InInventory);
        }
    }
}
