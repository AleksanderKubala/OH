using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of a better solution
    public class InteractionOpen : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;
        [SerializeField]
        private InteractableState _targetState;

        protected override InteractableObject AssociatedInteractable => _openable;

        public override void Perform(EntityController interactingEntity)
        {
            //var successful = true;

            if (failingStateSet.IsFulfilled(_openable.CurrentState))
            {
                //successful = false;
            }
            else
            {
                _openable.SetOpen();
                _openable.AddState(_targetState);
            }
        }
    }
}
