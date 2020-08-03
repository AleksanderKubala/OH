using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.Interactions;
using UnityEngine;

namespace Assets.UI
{
    //TODO: generalise UIInventorySpaceContentPanel, UIInventoryInteractionPanel, UIInventorySpaceTabPanel
    public class UIInventoryInteractionPanel : UIDynamicContentPanel<Interaction, UIInventoryInteractionButton>
    {
        private LinkedList<IInteractable> _toggledInventoryItems;

        protected override Transform ContentsParent => transform; 

        protected void Awake()
        {
            _toggledInventoryItems = new LinkedList<IInteractable>();
        }

        public void OnInventoryItemDeselected(IInteractable interactable)
        {
            HashSet<Interaction> interactionsSet = interactable.Interactions;
            _toggledInventoryItems.Remove(interactable);

            for(int i = 0; i < _unusedElementsSubListIndex; i++)
            {
                _contentElements[i].WithdrawInteractionSupport(interactionsSet);
                if(_contentElements[i].InteractionIsSupported == false)
                {
                    ResetContentElementButton(_contentElements[i], null);
                }
            }
            RepositionElements(Comparer<UIInventoryInteractionButton>.Default);
            _unusedElementsSubListIndex = _contentElements.FindIndex(x => x.Interaction == null);
        }

        public void OnInventoryItemSelected(IInteractable interactable)
        {
            HashSet<Interaction> interactionsSet = interactable.Interactions;
            _toggledInventoryItems.AddLast(interactable);
            if (_contentElements.Count < interactionsSet.Count)
            {
                CreateMultipleUIContentElements(interactionsSet.Count - _contentElements.Count);
            }
            var newInteractions = interactionsSet.Except(_contentElements.GetRange(0, _unusedElementsSubListIndex).Select(x => x.Interaction));
            if (newInteractions.Any())
            {
                AppendUIContentElement(newInteractions);
            }

            _contentElements.ForEach(x => x.SupportInteraction(interactionsSet));
            RepositionElements(Comparer<UIInventoryInteractionButton>.Default);
            _unusedElementsSubListIndex = _contentElements.FindIndex(x => x.Interaction == null);
        }

        public void OnInventoryItemButtonAdded(UIInventorySpaceContentsItem itemToggleButton)
        {
            itemToggleButton.InventoryItemSelected.AddListener(OnInventoryItemSelected);
            itemToggleButton.InventoryItemDeselected.AddListener(OnInventoryItemDeselected);
        }

        protected override void ResetContentElementButton(UIInventoryInteractionButton interactionButton, Interaction interaction)
        {
            interactionButton.Interaction = interaction;
        }

        protected override UIInventoryInteractionButton GetUIContentElementWithContent(Interaction interaction)
        {
            return _contentElements.First(x => x.Interaction.Equals(interaction));
        }

        protected override bool IsUIElementUnused(UIInventoryInteractionButton uiElement)
        {
            return uiElement.Interaction == null;
        }
    }
}
