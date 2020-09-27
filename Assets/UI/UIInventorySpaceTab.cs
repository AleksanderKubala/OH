using System;
using System.Linq;
using Assets.Interactables;
using Assets.Inventory;
using Assets.Inventory.Events;
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
        private IInventorySpace _inventorySpace;
        private bool _wasToggled;

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

        public Toggle Toggle { get; private set; }

        private void Awake()
        {
            Toggle = GetComponent<Toggle>();
            InventorySpaceToDisplay = _inventorySpace;
            _wasToggled = Toggle.isOn;
        }

        private void Start()
        {

        }

        public void OnInventorySpaceTabSelected(bool isToggled)
        {
            if(isToggled && !_wasToggled)
            {
                _contentsPanel.ResetDisplayedContents(_inventorySpace);
                Toggle.targetGraphic.color = Color.yellow;
                _wasToggled = true;
            }
            else if(!isToggled && _wasToggled)
            {
                Toggle.targetGraphic.color = Color.white;
                _wasToggled = false;
            }
        }

        public void OnItemWithdrawn(object sender, ItemAddedRemovedEventArgs args)
        {
            if(ReferenceEquals(args.InventorySpace, _inventorySpace) && _wasToggled)
            {
                _contentsPanel.RemoveContentFromUIElement(args.Interactable);
            }
        }

        public void OnItemStored(object sender, ItemAddedRemovedEventArgs args)
        {
            if (ReferenceEquals(args.InventorySpace, _inventorySpace) && _wasToggled)
            {
                _contentsPanel.SetContentInUIElement(args.Interactable);
            }
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
