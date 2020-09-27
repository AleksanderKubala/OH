using UnityEngine;

namespace Assets.Interactables
{
    [CreateAssetMenu(fileName = "InteractablesStates", menuName = "Static/Interactables States")]
    public class InteractablesStates : ScriptableObject
    {
        private static InteractablesStates _instance;

        [SerializeField]
        private InteractableState _open;
        [SerializeField]
        private InteractableState _closed;
        [SerializeField]
        private InteractableState _inInventory;
        [SerializeField]
        private InteractableState _locked;
        [SerializeField]
        private InteractableState _unlocked;

        public InteractablesStates()
        {
            if(_instance != null)
            {
                throw new System.Exception("InteractableStates class instance already exists.");
            }
            _instance = this;
        }

        public static InteractableState Open => _instance._open;
        public static InteractableState Closed => _instance._closed;
        public static InteractableState InInventory => _instance._inInventory;
        public static InteractableState Locked => _instance._locked;
        public static InteractableState Unlocked => _instance._unlocked;

    }
}
