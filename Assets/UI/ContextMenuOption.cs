using System;
using Assets.Managers;
using Assets.UI.Events;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.UI
{
    public class ContextMenuOption : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;

        public string OptionTitle { set => _text.text = value ?? "";}

        public UnityEvent ContextOptionSelected;

        private void Awake()
        {
            gameObject.SetActive(false);
            ContextOptionSelected = new UnityEvent();
            _button.onClick.AddListener(OnContextButtonClicked);
        }

        private void OnContextButtonClicked()
        {
            ContextOptionSelected?.Invoke();
            UIManager.Instance.CollapseContextMenu();
        }
    }
}
