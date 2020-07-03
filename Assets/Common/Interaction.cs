using UnityEngine;
using Asset.OnlyHuman.Characters;
using UnityEngine.Events;
using Assets.UI;

namespace Assets.Common
{
    public abstract class Interaction : IInteraction, IContextMenuSubscriber
    {
        protected Transform _interactionSource;

        public UnityAction OnSelectedCallback => EnqueueInteractionForActivePlayer;
        public abstract string OptionTitle { get; }

        public Interaction(GameObject interactionSource)
        {
            _interactionSource = interactionSource.transform;
        }

        public abstract void SetInteractionSourceAsTarget(EntityController entityInitiatingInteraction);
        public abstract void Perform();
        private void EnqueueInteractionForActivePlayer()
        {

        }
    }
}
