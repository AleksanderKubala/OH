using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Assets.Interactables;
using Assets.Items;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    //TODO: Reconsider inventory, inventory UI and items implementation. Eight now interactions are attached to gameObjects and dropping inventory contents (or any other interaction) from inventory UI  is impossible.
    public class UIInventorySpaceContentsItem : MonoBehaviour, ITooltipSubscriber, IComparable<UIInventorySpaceContentsItem>
    {
        [SerializeField]
        private Text _label;
        private Toggle _toggle;
        private IInteractable _interactableObject;

        [HideInInspector]
        public InventoryItemEvent InventoryItemSelected;
        [HideInInspector]
        public InventoryItemEvent InventoryItemDeselected;

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
                SetLabel();
            }
        }

        public bool Toggled
        {
            get => _toggle.isOn;
            set => _toggle.isOn = value;
        }

        private void Awake()
        {
            //InventoryItemDeselected = new InventoryItemEvent();
            //InventoryItemDeselected = new InventoryItemEvent();
            _toggle = GetComponent<Toggle>();
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
            if(value)
            {
                InventoryItemSelected?.Invoke(_interactableObject);
            }
            else
            {
                InventoryItemDeselected?.Invoke(_interactableObject);
            }
        }

        private void SetLabel()
        {
            if(_interactableObject != null)
            {
                _label.text = _interactableObject.Name ?? "null";
            }
        }

        public int CompareTo(UIInventorySpaceContentsItem other)
        {
            if (other != null && other.Interactable != null && this.Interactable != null)
            {
                return Interactable.Name.CompareTo(other.Interactable.Name);
            }
            else if (this.Interactable != null && other.Interactable == null)
            {
                return -1;
            }
            else if (this.Interactable == null && other.Interactable != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
