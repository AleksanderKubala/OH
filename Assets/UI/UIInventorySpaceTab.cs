using System;
using Assets.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventorySpaceTab : MonoBehaviour
    {
        [SerializeField]
        private UIInventorySingleSpaceContentPanel _contentsPanel;
        [SerializeField]
        private Text _label;
        private IInventorySpace _inventorySpace;

        public IInventorySpace InventorySpaceToDisplay
        {
            get
            {
                return _inventorySpace;
            }
            set
            {
                _inventorySpace = value;
                gameObject.SetActive(_inventorySpace != null);
                
            }
        }

        private void Start()
        {
            _label.text = "Test Space";
            InventorySpaceToDisplay = _inventorySpace;
        }

        public void OnInventorySpaceTabSelected(bool isToggled)
        {
            if(isToggled)
            {
                _contentsPanel.ChangeDisplayedInventoryContents(_inventorySpace.GetAllItems());
            }

        }
    }
}
