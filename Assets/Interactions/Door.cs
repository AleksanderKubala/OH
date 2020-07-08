using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.UI;
using UnityEngine;

namespace Assets.Interactions
{
    public class Door : InteractableObject, IInteractableOpenable, IInteractableCloseable
    {
        [SerializeField]
        private GameObject _hinge;
        [SerializeField]
        private bool _isOpen;

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            private set
            {
                if(value)
                {
                    DefaultInteraction = Close;
                }
                else
                {
                    DefaultInteraction = Open;
                }
                _isOpen = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            IsOpen = _isOpen;
        }

        protected override void Start()
        {
            _contextMenuHandler.Subscribe(new ContextInteractionSubscription(Open, "Open"));
            _contextMenuHandler.Subscribe(new ContextInteractionSubscription(Close, "Close"));
        }

        public void Close(EntityController interactingEntity)
        {
            AssignInteraction(interactingEntity, OnInteractedClose);
        }

        public void Open(EntityController interactingEntity)
        {
            AssignInteraction(interactingEntity, OnInteractedOpen);
        }

        private void OnInteractedOpen(EntityController interactinEntity)
        {
            if(!IsOpen)
            {
                _hinge.transform.rotation *= Quaternion.Euler(0.0f, 90.0f, 0.0f);
                IsOpen = true;
            }
        }

        private void OnInteractedClose(EntityController interactinEntity)
        {
            if(IsOpen)
            {
                _hinge.transform.rotation *= Quaternion.Euler(0.0f, -90.0f, 0.0f);
                IsOpen = false;
            }
        }
    }
}
