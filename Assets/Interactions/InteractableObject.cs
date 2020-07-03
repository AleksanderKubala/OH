using System.Collections.Generic;
using Assets.Interactions.Events;
using Assets.Managers;
using Assets.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Interactions
{
    public abstract class InteractableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private Outline _outline;
        [SerializeField]
        private UITextDisplay _nameDisplay;


        public InteractableHighlightedEvent InteractableHighlighted;
        public InteractableUnhighlightedEvent InteractableUnhighlighted;

        protected InteractionCall DefaultInteraction;

        protected virtual void Awake()
        {
            InteractableHighlighted = new InteractableHighlightedEvent();
            InteractableUnhighlighted = new InteractableUnhighlightedEvent();
        }

        protected void Start()
        {
            InteractableHighlighted.AddListener(_nameDisplay.Show);
            InteractableUnhighlighted.AddListener(_nameDisplay.Hide);
            _outline.enabled = false;            
        }

        protected void OnBecameVisible()
        {
            _nameDisplay.AcquireTextElement();
            //UIManager.Instance.AssociateUINameDisplayWithInteractable(this);
        }

        protected void OnBecameInvisible()
        {
            _nameDisplay.ReleaseTextElement();
            //InteractableHighlighted.RemoveAllListeners();
            //InteractableUnhighlighted.RemoveAllListeners();
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
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                ExpandContextMenu();
            }
        }

        public void ExpandContextMenu()
        {
            var contextMenu = UIManager.Instance.GetContextMenu();
            var interactions = EnumerateInteractions();
            
            foreach(var interaction in interactions)
            {
                contextMenu.AddContextAction(interaction);
            }

            contextMenu.Display(Input.mousePosition);
        }

        protected abstract IEnumerable<ContextActionSubscription> EnumerateInteractions();
    }
}
