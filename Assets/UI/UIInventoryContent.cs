﻿using System.Collections.Generic;
using System.Linq;
using Assets.Inventory;
using Assets.Managers;
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
        private List<UIInventorySpaceTab> _inventorySpaceTabs;
        
        //TODO: for now - replace with proper code later
        private IInventory _displayedInventory;

        //TODO: for now - replace with proper code later
        private void Awake()
        {

        }

        private void Start()
        {
            _displayedInventory = GameManager.Player.Inventory;
            Display(_displayedInventory);
            
        }

        //TODO: for now - replace with proper code later
        public void Display(IInventory inventory)
        {
            //_displayedInventory = inventory;
            var inventorySpaces = _displayedInventory.GetInventorySpaces(x => true);
            _inventorySpaceTabs[0].InventorySpaceToDisplay = inventorySpaces.First();
        }
    }
}
