using UnityEngine;
using Asset.OnlyHuman.Characters;
using UnityEngine.Events;
using Assets.UI;

namespace Assets.Interactions
{
    public  class Interaction : IInteraction
    {
        public Interaction(GameObject interactionSource)
        {
            InteractionSource = interactionSource.transform;
        }

        public UnityAction InteractionPerformed;

        public Transform InteractionSource {get; private set; }

        public void Perform(EntityController interactingEntity)
        {
            InteractionPerformed?.Invoke();
        }
    }
}
