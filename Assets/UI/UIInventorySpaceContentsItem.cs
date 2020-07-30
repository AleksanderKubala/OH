using Assets.Interactables;
using Assets.Items;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    //TODO: Reconsider inventory, inventory UI and items implementation. Eight now interactions are attached to gameObjects and dropping inventory contents (or any other interaction) from inventory UI  is impossible.
    public class UIInventorySpaceContentsItem : MonoBehaviour, ITooltipSubscriber
    {
        [SerializeField]
        private Text _label;
        private IInteractable _interactableObject;

        public InventoryItemToggledEvent InventoryItemToggled;

        public IInteractable Interactable
        {
            get
            {
                return _interactableObject;
            }
            set
            {
                _interactableObject = value;
                gameObject.SetActive(_interactableObject != null);
                if(gameObject.activeSelf)
                {
                    _label.text = _interactableObject.Name;
                }
            }
        }

        private void Awake()
        {
            Interactable = _interactableObject;
        }

        public void OnTooltipDisplayed(TooltipDisplayedEventArgs args)
        {
            if(_interactableObject != null)
            {
                args.TooltipText = _interactableObject.GetDescription();
            }
        }

        public void OnToggleValueChanged(bool value)
        {
            InventoryItemToggled?.Invoke(value, _interactableObject);
        }
    }
}
