﻿using System.Collections.Generic;
using Assets.Common;
using Assets.UI;
using UnityEngine;

namespace Assets.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField]
        private GameObject _screenSpaceCanvas;
        [SerializeField]
        private GameObject _worldSpaceCanvas;
        [SerializeField]
        private UIContextMenu _contextMenu;
        [SerializeField]
        private UITooltip _tooltip;

        private void Awake()
        {
            Instance = this;
        }


        public UIContextMenu GetContextMenu()
        {
            return _contextMenu;
        }

        public UITooltip GetTooltip()
        {
            return _tooltip;
        }
    }
}

