using System;
using Assets.Managers;
using Assets.UI.Events;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIContextAction : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;
        private IContextActionSubscriber _subscription;

        public IContextActionSubscriber Subscription
        {
            get
            {
                return _subscription;
            }
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
                        ContextActionSelected.RemoveListener(_subscription.OnSelectedInContextMenu);
                    }
                    _text.text = value.ContextActionTitle;
                    ContextActionSelected.AddListener(value.OnSelectedInContextMenu);
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
