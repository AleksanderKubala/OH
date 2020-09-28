using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionLock : Interaction
    {
        [SerializeField]
        private Interactable _interactable;

        protected override Interactable AssociatedInteractable => _interactable;

        public override void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments)
        {
            if(IsEffective && AreArgumentsCorrect(arguments))
            {
                _interactable.AddState(InteractablesStates.Locked);
            }
        }

        public override Transform GetInteractionSource()
        {
            return AssociatedInteractable.transform;
        }

        protected override void OnInteractableStateChanged()
        {
            IsEffective = AssociatedInteractable.IsInState(InteractablesStates.Unlocked);
        }
    }
}
