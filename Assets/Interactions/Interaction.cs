using UnityEngine;
using Asset.OnlyHuman.Characters;
using UnityEngine.Events;
using Assets.UI;
using Assets.Interactions.Events;

namespace Assets.Interactions
{
    public  class Interaction : IInteraction
    {
        public Interaction(GameObject interactionSource, InteractionPerformedCallback interactionPerformedCallback)
        {
            InteractionSource = interactionSource.transform;
            Perform = interactionPerformedCallback;
        }

        public Transform InteractionSource { get; private set; }
        public InteractionPerformedCallback Perform { get; private set; }
    }
}
