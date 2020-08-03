using System;
using Assets.Interactables;
using Assets.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventorySpaceTab : MonoBehaviour, IInventoryStoreSubscriber, IInventoryWithdrawSubscriber, IComparable<UIInventorySpaceTab>
    {
        [SerializeField]
        private UIInventorySpaceContentsPanel _contentsPanel;
        [SerializeField]
        private Text _label;
        private Toggle _toggle;
        private IInventorySpace _inventorySpace;

        public IInventorySpace InventorySpaceToDisplay
        {
            get
            {
                return _inventorySpace;
            }
            set
            {
                SetUpInventorySpaceReference(value);
                gameObject.SetActive(_inventorySpace != null);
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
            _toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            InventorySpaceToDisplay = _inventorySpace;
        }

        public void OnInventorySpaceTabSelected(bool isToggled)
        {
            if(isToggled)
            {
                _contentsPanel.ResetDisplayedContents(_inventorySpace);
            }
        }

        public void OnItemWithdrawn(object sender, IInteractable item)
        {
            _contentsPanel.RemoveContentFromUIElement(item);
        }

        public void OnItemStored(object sender, IInteractable item)
        {
            _contentsPanel.AppendUIContentElement(item);
        }

        private void SetUpInventorySpaceReference(IInventorySpace space)
        {
            if(_inventorySpace != null)
            {
                _inventorySpace.ItemTakenOut -= OnItemWithdrawn;
                _inventorySpace.ItemPutInside -= OnItemStored;
            }
            if(space != null)
            {
                space.ItemPutInside += OnItemStored;
                space.ItemTakenOut += OnItemWithdrawn;
            }
            _inventorySpace = space;
        }

        private void SetLabel()
        {
            if(_inventorySpace != null)
            {
                _label.text = _inventorySpace.Name ?? "null";
            }
        }

        public int CompareTo(UIInventorySpaceTab other)
        {
            if (other != null && other.InventorySpaceToDisplay != null && this.InventorySpaceToDisplay != null)
            {
                return InventorySpaceToDisplay.Name.CompareTo(other.InventorySpaceToDisplay.Name);
            }
            else if (this.InventorySpaceToDisplay != null && other.InventorySpaceToDisplay == null)
            {
                return -1;
            }
            else if (this.InventorySpaceToDisplay == null && other.InventorySpaceToDisplay != null)
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
