using OHLogic.Inventory;
using UnityEngine;

namespace Assets.UI
{
    public class UIInventorySpaceTab : MonoBehaviour
    {
        [SerializeField]
        private UIInventorySingleSpaceContentPanel _contentsPanel;
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
                if(_inventorySpace == null)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
        }

        private void Start()
        {
            InventorySpaceToDisplay = _inventorySpace;
        }

        public void OnInventorySpaceTabSelected()
        {
            //
        }
    }
}
