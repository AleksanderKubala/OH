using Assets.Interactables.Events;
using Assets.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Interactables
{
    public class InteractiveObjectHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Outline _outline;
        [SerializeField]
        private UITextDisplay _nameDisplay;

        public InteractableHighlightedEvent InteractableHighlighted;
        public InteractableUnhighlightedEvent InteractableUnhighlighted;

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
    }
}
