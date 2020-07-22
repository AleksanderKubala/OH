using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of a better solution
    public class InteractionOpen : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;

        public override void Perform(EntityController interactingEntity)
        {
            //var successful = true;

            if (_openable.HasLock && _openable.KeyLock.IsLocked)
            {
                //successful = false;
            }
            else
            {
                _openable.SetOpen();
            }

            //return successful;
            //_openable.Open(interactingEntity);
            SetEffectiveByInteractableState();
        }

        protected override void SetEffectiveByInteractableState()
        {
            if (_openable.IsOpen && IsEffective)
            {
                IsEffective = false;
            }
            else
            {
                IsEffective = true;
            }
        }
    }
}
