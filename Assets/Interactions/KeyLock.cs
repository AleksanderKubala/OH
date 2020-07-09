using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public class KeyLock : MonoBehaviour
    {
        [SerializeField]
        private bool _isLocked;

        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
            }
        }
        private void Awake()
        {
            IsLocked = _isLocked;
        }

        public bool Lock(EntityController interactingEntity)
        {
            IsLocked = true;

            return true;
        }

        public bool Unlock(EntityController interactingEntity)
        {
            IsLocked = false;

            return false;
        }
    }
}
