using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.Interactions;
using Assets.Managers;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    //TODO: generalise UIInventorySpaceContentPanel, UIInventoryInteractionPanel, UIInventorySpaceTabPanel
    public class UIInventoryInteractionPanel : UIDynamicContentPanel<Interaction, UIInventoryInteractionButton>
    {
        private LinkedList<IInteractable> _toggledInventoryItems;

        protected override Transform UIElementParent => transform; 

        protected void Awake()
        {
            _toggledInventoryItems = new LinkedList<IInteractable>();
        }

        private void Start()
        {
            foreach(var interactionButton in _uiElements)
            {
                interactionButton.InteractionSelected.AddListener(OnInteractionSelected);
            }
        }

        public void OnInventoryItemDeselected(IInteractable interactable)
        {
            InteractionSet interactionsSet = interactable.Interactions;
            _toggledInventoryItems.Remove(interactable);

            for(int i = 0; i < _unusedUIElementsSubListIndex; i++)
            {
                _uiElements[i].WithdrawInteractionSupport(interactionsSet);
                if(_uiElements[i].InteractionIsSupported == false)
                {
                    ResetUIElement(_uiElements[i], null);
                }
            }
            RepositionUIElements(Comparer<UIInventoryInteractionButton>.Default);
            _unusedUIElementsSubListIndex = _uiElements.FindIndex(x => x.Interaction == null);
        }

        public void OnInventoryItemSelected(IInteractable interactable)
        {
            InteractionSet interactionsSet = interactable.Interactions;
            _toggledInventoryItems.AddLast(interactable);
            var newInteractions = interactionsSet.Except(_uiElements.GetRange(0, _unusedUIElementsSubListIndex).Select(x => x.Interaction));
            if (newInteractions.Any())
            {
                var newUIElementsCount = newInteractions.Count() - UnusedUIElementsCount;
                if (newUIElementsCount > 0)
                {
                    CreateMultipleUIElements(newUIElementsCount);
                }
                SetContentInUIElement(newInteractions);
            }

            _uiElements.ForEach(x => x.SupportInteraction(interactionsSet));
            RepositionUIElements(Comparer<UIInventoryInteractionButton>.Default);
            _unusedUIElementsSubListIndex = _uiElements.FindIndex(x => x.Interaction == null);
        }

        public void OnInventoryItemButtonAdded(UIInventorySpaceContentsItem itemToggleButton)
        {
            itemToggleButton.InventoryItemSelected.AddListener(OnInventoryItemSelected);
            itemToggleButton.InventoryItemDeselected.AddListener(OnInventoryItemDeselected);
        }

        public void OnInteractionSelected(InventoryInteractionSelectedEventArgs args)
        {
            foreach(var interactable in _toggledInventoryItems)
            {
                var attempt = interactable.Interactions.First(x => x.Equals(args.Interaction)).GetInteractionAttempt();
                attempt.InteractingEntity = GameManager.Player;
                GameManager.Player.AddActionToPerform(attempt);
            }

        }

        protected override void ResetUIElement(UIInventoryInteractionButton interactionButton, Interaction interaction)
        {
            interactionButton.Interaction = interaction;
        }

        protected override UIInventoryInteractionButton GetUIElementWithContent(Interaction interaction)
        {
            return _uiElements.First(x => x.Interaction.Equals(interaction));
        }

        protected override bool IsUIElementUnused(UIInventoryInteractionButton uiElement)
        {
            return uiElement.Interaction == null;
        }

        protected override UIInventoryInteractionButton CreateUIElement()
        {
            var newButton =  base.CreateUIElement();
            newButton.InteractionSelected.AddListener(OnInteractionSelected);

            return newButton;
        }
    }
}
