using Assets.Movement.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Movement
{
    public class DestinationFlag : MonoBehaviour
    {
        [SerializeField]
        private Transform _parent;
        private Vector3 _position;

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
                DestinationChanged?.Invoke(GetWorldSpaceDestination());
                transform.hasChanged = false;
            }
        }

        public void Set(Transform parent, Vector3 position)
        {
            _parent = parent;
            _position = position;
            transform.parent = parent;
            transform.position = position;
        }

        private Vector3 GetWorldSpaceDestination()
        {
            Vector3 worldSpacePosition;
            if(_parent == null)
            {
                worldSpacePosition = _position;
            }
            else
            {
                worldSpacePosition = _parent.TransformPoint(_position);
            }

            return worldSpacePosition;
        }
    }
}
