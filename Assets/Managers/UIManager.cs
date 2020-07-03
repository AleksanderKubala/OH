using System.Collections.Generic;
using Assets.Common;
using Assets.UI;
using UnityEngine;

namespace Assets.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField]
        private GameObject _canvas;
        [SerializeField]
        private UIHighlightTextDisplay _nameDisplay;
        [SerializeField]
        private ContextMenu _contextMenu;

        private void Awake()
        {
            Instance = this;
        }

        public void AssociateUINameDisplayWithInteractable(InteractableObject interactable)
        {
            interactable.InteractableHighlighted.AddListener(_nameDisplay.OnInteractableHighlighted);
            interactable.InteractableUnhighlighted.AddListener(_nameDisplay.OnInteractableUnhighlighted);
            _nameDisplay.transform.forward = Camera.main.transform.forward;
            _nameDisplay.transform.position = interactable.transform.position - Camera.main.transform.forward + Vector3.up;
            _nameDisplay.Text = interactable.HighlightText;
        }

        public void ExpandInteractionContextMenu(IEnumerable<IContextMenuSubscriber> contextMenuSubscribers)
        {
            foreach(var subscriber in contextMenuSubscribers)
            {
                var contextOption = _contextMenu.GetUnassignedContextOption();
                contextOption.OptionTitle = subscriber.OptionTitle;
                contextOption.ContextOptionSelected.AddListener(subscriber.OnSelectedCallback);
            }

            _contextMenu.Display(Input.mousePosition);
        }

        public void CollapseContextMenu()
        {
            _contextMenu.Hide();
        }
    }
}

