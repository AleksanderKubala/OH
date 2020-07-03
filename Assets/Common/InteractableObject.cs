using System.Collections.Generic;
using Assets.Common.Events;
using Assets.Managers;
using UnityEngine;

namespace Assets.Common
{
    public class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        private Outline _outline;
        [SerializeField]
        private string _highlightText;

        public InteractableHighlightedEvent InteractableHighlighted;
        public InteractableUnhighlightedEvent InteractableUnhighlighted;

        public Interaction DefaultInteraction { get; protected set; }
        protected LinkedList<Interaction> Interactions { get; set; }

        public string HighlightText
        {
            get => _highlightText;
            set => _highlightText = value ?? "";
        }

        private void Awake()
        {
            InteractableHighlighted = new InteractableHighlightedEvent();
            InteractableUnhighlighted = new InteractableUnhighlightedEvent();
        }

        private void Start()
        {
            _outline.enabled = false;            
        }

        protected void OnBecameVisible()
        {
            UIManager.Instance.AssociateUINameDisplayWithInteractable(this);
        }

        protected void OnBecameInvisible()
        {
            InteractableHighlighted.RemoveAllListeners();
            InteractableUnhighlighted.RemoveAllListeners();
        }

        protected void OnMouseEnter()
        {
            _outline.enabled = true;
            InteractableHighlighted?.Invoke();
        }

        protected void OnMouseExit()
        {
            _outline.enabled = false;
            InteractableUnhighlighted?.Invoke();
        }

        protected void OnMouseUpAsButton()
        {
            if(Input.GetMouseButton(0))
            {

            }
            if(Input.GetMouseButtonUp(1))
            {
                UIManager.Instance.ExpandInteractionContextMenu(Interactions);
            }
        }
    }
}
