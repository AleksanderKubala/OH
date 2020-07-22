using System.Collections.Generic;
using OHLogic.Inventory;
using UnityEngine;

namespace Assets.UI
{
    public class UIInventoryContent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventorySpaceTabPrefab;
        [SerializeField]
        private GameObject _inventorySpaceTabsPanel;
        [SerializeField]
        private List<GameObject> _inventorySpaceTabs;
        private IInventory _displayedInventory;

        public void Display(IInventory inventory)
        {
            _displayedInventory = inventory;
        }
    }
}
