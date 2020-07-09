using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionOpen : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;

        public override bool Perform(EntityController interactingEntity)
        {
            var possible = base.Perform(interactingEntity);
            _openable.Open(interactingEntity);

            return possible;
        }
    }
}
