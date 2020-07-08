using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Interactions.Events;
using Assets.Managers;
using Assets.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Interactions
{
    public abstract class InteractableObject : ContextMenuSubscriber, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private Outline _outline;
        [SerializeField]
        private UITextDisplay _nameDisplay;


        public InteractableHighlightedEvent InteractableHighlighted;
        public InteractableUnhighlightedEvent InteractableUnhighlighted;

        protected InteractionPerformedCallback DefaultInteraction;

        protected virtual void Awake()
        {
            InteractableHighlighted = new InteractableHighlightedEvent();
            InteractableUnhighlighted = new InteractableUnhighlightedEvent();
        }

        protected virtual void Start()
        {
            InteractableHighlighted.AddListener(_nameDisplay.Show);
            InteractableUnhighlighted.AddListener(_nameDisplay.Hide);
            _outline.enabled = false;
        }

        protected void OnBecameVisible()
        {
            _nameDisplay.AcquireTextElement();
        }

        protected void OnBecameInvisible()
        {
            _nameDisplay.ReleaseTextElement();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _outline.enabled = true;
            InteractableHighlighted?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _outline.enabled = false;
            InteractableUnhighlighted?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                DefaultInteraction?.Invoke(GameManager.Player);
            }
        }

        protected void AssignInteraction(EntityController interactingEntity, InteractionPerformedCallback interactionPerformCallback)
        {
            var interaction = new Interaction(gameObject, interactionPerformCallback);
            interactingEntity.AddInteractionToPerform(interaction);
        }
    }
}
