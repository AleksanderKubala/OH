using Assets.Interactables;
using Boo.Lang;
using UnityEngine;

namespace Assets.Interactions
{
    public class CompoundKeyLock : InteractableObjectProperty
    {
        [SerializeField]
        private List<Interactable> _keylocks;

        private void Start()
        {
            foreach (var keyLock in _keylocks)
            {
                keyLock.InternalStateChanged.AddListener(OnLockStateChanged);
            }
        }

        private void OnLockStateChanged()
        {
            var unlocked = false;

            foreach (var keyLock in _keylocks)
            {
                unlocked |= keyLock.IsInState(InteractablesStates.Unlocked);
            }

            if(unlocked)
            {
                AssociatedInteractable.AddState(InteractablesStates.Unlocked);
            }
            else
            {
                AssociatedInteractable.AddState(InteractablesStates.Locked);
            }
        }
    }
}
