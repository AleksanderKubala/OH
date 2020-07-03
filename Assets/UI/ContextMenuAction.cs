using System;
using Assets.Managers;
using Assets.UI.Events;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.UI
{
    public class ContextMenuAction : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;
        private ContextActionSubscription _subscription;

        public ContextActionSubscription Subscription
        {
            set
            {
                if(value == null)
                {
                    ContextActionSelected.RemoveAllListeners();
                }
                else
                {
                    if(_subscription != null)
                    {
                        ContextActionSelected.RemoveListener(_subscription.OnContextActionSelected);
                    }
                    _text.text = value.ActionTitle;
                    ContextActionSelected.AddListener(value.OnContextActionSelected);
                    _subscription = value;
                }
            }
        }

        private ContextActionSelectedEvent ContextActionSelected;

        private void Awake()
        {
            ContextActionSelected = new ContextActionSelectedEvent();
            gameObject.SetActive(false);
        }

        public void OnContextButtonClicked()
        {
            ContextActionSelected?.Invoke();
            UIManager.Instance.GetContextMenu().Hide();
        }
    }
}
