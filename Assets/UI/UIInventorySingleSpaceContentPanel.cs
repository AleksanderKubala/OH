﻿using System;
using System.Collections.Generic;
using System.Linq;
using OHLogic.Inventory;
using OHLogic.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventorySingleSpaceContentPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventoryContentElementPrefab;
        [SerializeField]
        private GameObject _content;
        [SerializeField]
        private List<GameObject> _contentElements;


        public void ChangeDisplayedInventoryContents(IEnumerable<IItem> itemsToDisplay)
        {
            var contentElementsDifference = itemsToDisplay.Count() - _contentElements.Count;
            PrepareUIContentElements(contentElementsDifference);

            var itemsIterator = itemsToDisplay.GetEnumerator();
            var contentElementsIterator = _contentElements.GetEnumerator();
            while(contentElementsIterator.MoveNext() && itemsIterator.MoveNext())
            {

            }
        }

        private void PrepareUIContentElements(int expectedVsPreparedDifference)
        {
            int loopIteratorStep = Math.Sign(expectedVsPreparedDifference);

            //may be costly computation-wise - candidate for pooling
            for (int i = 0; i != expectedVsPreparedDifference; i += loopIteratorStep)
            {
                if(expectedVsPreparedDifference < 0)
                {
                    //
                }
                if(expectedVsPreparedDifference > 0)
                {
                    //
                }
            }
        }
    }
}