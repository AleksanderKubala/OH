using System;
using Assets.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventorySpaceTab : MonoBehaviour
    {
        [SerializeField]
        private UIInventorySpaceContentsPanel _contentsPanel;
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
                if(gameObject.activeSelf)
                {
                    _label.text = _inventorySpace.Name;
                }
            }
        }

        private void Start()
        {
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
