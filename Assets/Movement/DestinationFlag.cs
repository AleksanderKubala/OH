using Assets.Movement.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Movement
{
    public class DestinationFlag : MonoBehaviour
    {
        [SerializeField]
        public DestinationChangedEvent DestinationChanged;
        public UnityEvent DestinationReached;

        private void Awake()
        {
            transform.hasChanged = false;
        }

        private void Update()
        {
            if(transform.hasChanged)
            {
                DestinationChanged?.Invoke(transform.position);
                transform.hasChanged = false;
            }
        }

        public void Set(Transform parent, Vector3 position)
        {
            transform.parent = parent;
            transform.localPosition = position;
        }
    }
}
