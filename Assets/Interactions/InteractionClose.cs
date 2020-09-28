using System;
using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public class InteractionClose : Interaction
    {
        [SerializeField]
        private Openable _openable;

        protected override Interactable AssociatedInteractable => _openable.AssociatedInteractable;

        protected override void Start()
        {
            base.Start();
        }

        public override void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments)
        {
            if (IsEffective)
            {
                _openable.SetClosed();
                AssociatedInteractable.AddState(InteractablesStates.Closed);
            }
        }

        public override Transform GetInteractionSource()
        {
            return _openable.transform;
        }

        protected override void OnInteractableStateChanged()
        {
            IsEffective = AssociatedInteractable.IsInState(InteractablesStates.Open) && !AssociatedInteractable.IsInState(InteractablesStates.Locked);
        }
    }
}
