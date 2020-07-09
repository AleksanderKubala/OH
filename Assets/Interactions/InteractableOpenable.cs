﻿using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Interactions
{
    public abstract class InteractableOpenable : InteractableObject
    {
        [SerializeField]
        private KeyLock _lock;
        [SerializeField]
        private bool _isOpen;
        [SerializeField]
        private Interaction _openInteraction;
        [SerializeField]
        private Interaction _closeInteraction;

        public KeyLock KeyLock => _lock;
        public bool HasLock => _lock != null;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                UpdateInteractions();
            }
        }

        protected virtual void Awake()
        {
            IsOpen = _isOpen;

        }

        public /*bool*/ void Open(EntityController interactingEntity)
        {
            //var successful = true;

            if(HasLock && KeyLock.IsLocked)
            {
                //successful = false;
            }
            else
            {
                SuccessfullyOpened();
                IsOpen = true;
            }

            //return successful;
        }

        public /*bool*/void Close(EntityController interactingEntity)
        {
            //var successful = true;

            if(IsOpen && HasLock && KeyLock.IsLocked)
            {
                //successful = false;
            }
            else
            {
                SuccessfullyClosed();
                IsOpen = false;
            }

            //return successful;
        }

        protected override void UpdateInteractions()
        {
            if(IsOpen)
            {
                _closeInteraction.IsEffective = true;
            }
            else
            {
                _openInteraction.IsEffective = true;
            }
        }

        protected abstract void SuccessfullyOpened();
        protected abstract void SuccessfullyClosed();
    }
}