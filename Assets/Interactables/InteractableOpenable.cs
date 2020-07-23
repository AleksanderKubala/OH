using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public abstract class InteractableOpenable : InteractableObject
    {
        [SerializeField]
        private KeyLock _lock;

        public KeyLock KeyLock => _lock;
        public bool HasLock => _lock != null;

        protected override void Awake()
        {
            base.Awake();
        }

        public abstract void SetOpen();
        public abstract void SetClosed();
    }
}
