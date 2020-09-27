using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Common;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of a better solution
    public class InteractionOpen : Interaction
    {
        [SerializeField]
        private Openable _openable;

        protected override Interactable AssociatedInteractable => _openable.AssociatedInteractable;

        public override void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments)
        {
            if(IsEffective)
            {
                _openable.SetOpen();
                AssociatedInteractable.AddState(InteractablesStates.Open);
            }
        }

        public override Transform GetInteractionSource()
        {
            return AssociatedInteractable.transform;
        }

        protected override void OnInteractableStateChanged()
        {
            IsEffective = AssociatedInteractable.IsInState(InteractablesStates.Closed) && !AssociatedInteractable.IsInState(InteractablesStates.Locked);
        }
    }
}
