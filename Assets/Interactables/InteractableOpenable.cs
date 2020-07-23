using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public abstract class InteractableOpenable : InteractableObject
    {
        [SerializeField]
        private KeyLock _lock;
        [SerializeField]
        private bool _isOpen;

        public KeyLock KeyLock => _lock;
        public bool HasLock => _lock != null;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            protected set
            {
                _isOpen = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            IsOpen = _isOpen;
        }

        public virtual void SetOpen()
        {
            IsOpen = true;
        }

        public virtual void SetClosed()
        {
            IsOpen = false;
        }
    }
}
