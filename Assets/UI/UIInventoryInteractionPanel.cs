using System.Collections.Generic;
using System.Linq;
using Assets.Interactables;
using Assets.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventoryInteractionPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _interactionButtonPrefab;
        [SerializeField]
        private List<UIInventoryInteractionButton> _unusedInteractionButtons;
        private List<UIInventoryInteractionButton> _activeInteractionButtons;
        private LinkedList<IInteractable> _toggledInventoryItems;

        private void Awake()
        {
            _activeInteractionButtons = new List<UIInventoryInteractionButton>(_unusedInteractionButtons.Count);
            _toggledInventoryItems = new LinkedList<IInteractable>();
        }


        public void OnInventoryItemToggled(bool toggled, IInteractable interactable)
        {
            _toggledInventoryItems.AddLast(interactable);
            HashSet<Interaction> interactionsSet = interactable.Interactions;

            if(toggled)
            {
                PrepareInteractionButtons(interactionsSet);
            }

            UpdateInteractionsSupport(toggled, interactionsSet);
            CleanActiveButtonsList(toggled);
        }

        public void OnInventoryItemButtonAdded(UIInventorySpaceContentsItem itemToggleButton)
        {
            itemToggleButton.InventoryItemToggled.AddListener(OnInventoryItemToggled);
        }

        private void UpdateInteractionsSupport(bool inSupportPath, HashSet<Interaction> interactionsSet)
        {
            foreach(var button in _activeInteractionButtons)
            {
                UpdateInteractionSupportOfSingleButton(button, inSupportPath, interactionsSet);
            }
        }

        private void UpdateInteractionSupportOfSingleButton(UIInventoryInteractionButton button, bool inSupportPath, HashSet<Interaction> interactionsSet)
        {
            bool interactionHasButton;

            if (inSupportPath)
            {
                interactionHasButton = button.SupportInteraction(interactionsSet);
            }
            else
            {
                interactionHasButton = button.WithdrawInteractionSupport(interactionsSet);
            }

            if (interactionHasButton)
            {
                interactionsSet.Remove(button.Interaction);
            }
        }

        private void PrepareInteractionButtons(HashSet<Interaction> newInteractions)
        {
            var unsupportedInteractions = newInteractions.Except(_activeInteractionButtons.Select(x => x.Interaction));
            var unsupportedInteractionsCount = unsupportedInteractions.Count();

            if (unsupportedInteractionsCount > _unusedInteractionButtons.Count)
            {
                AddInteractionButtons(unsupportedInteractionsCount - _unusedInteractionButtons.Count);
            }

            SetButtonsForUnsupportedInteractions(unsupportedInteractions);
        }

        private void AddInteractionButtons(int count)
        {

        }

        private void SetButtonsForUnsupportedInteractions(IEnumerable<Interaction> unsupportedInteractions)
        {
            var unsupportedInteractionsIterator = unsupportedInteractions.GetEnumerator();
            for (int j = _unusedInteractionButtons.Count - 1; unsupportedInteractionsIterator.MoveNext(); j--)
            {
                _unusedInteractionButtons[j].Interaction = unsupportedInteractionsIterator.Current;
                _activeInteractionButtons.Add(_unusedInteractionButtons[j]);
                _unusedInteractionButtons.RemoveAt(j);
            }
        }

        private void CleanActiveButtonsList(bool inSupportPath)
        {
            if(!inSupportPath)
            {
                var unusedButtonsAsActive = _activeInteractionButtons.Where(x => x.Interaction == null);
                foreach(var dirtyButton in unusedButtonsAsActive)
                {
                    _activeInteractionButtons.Remove(dirtyButton);
                    _unusedInteractionButtons.Add(dirtyButton);
                }
            }

            _activeInteractionButtons.Sort((l, r) => l.Interaction.Name.CompareTo(r.Interaction.Name));

            for(int i = 0; i < _activeInteractionButtons.Count; i++)
            {
                _activeInteractionButtons[i].transform.SetSiblingIndex(i);
            }
        }

    }
}
