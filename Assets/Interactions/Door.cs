using UnityEngine;
using UnityEngine.AI;

namespace Assets.Interactions
{
    public class Door : InteractableOpenable
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private HingeJoint _joint;
        [SerializeField]
        private NavMeshObstacle _navMeshObstacle;
        [SerializeField]
        private float _maxOpenDoorAngle;
        [SerializeField]
        private float _maxClosedDoorAngle;
        private JointLimits _openDoorLimits;
        private JointLimits _closedDoorLimits;

        protected override void Awake()
        {
            base.Awake();
            _openDoorLimits = new JointLimits
            {
                bounceMinVelocity = _joint.limits.bounceMinVelocity,
                bounciness = _joint.limits.bounciness,
                contactDistance = _joint.limits.contactDistance,
                min = _joint.limits.min,
                max = _maxOpenDoorAngle
            };

            _closedDoorLimits = new JointLimits
            {
                bounceMinVelocity = _joint.limits.bounceMinVelocity,
                bounciness = _joint.limits.bounciness,
                contactDistance = _joint.limits.contactDistance,
                min = _joint.limits.min,
                max = _maxClosedDoorAngle
            };
        }

        protected override void SuccessfullyOpened()
        {
            _joint.limits = _openDoorLimits;
            _navMeshObstacle.enabled = false;
            _rigidbody.AddForceAtPosition(transform.forward * 10, transform.localPosition);
        }

        protected override void SuccessfullyClosed()
        {
            _rigidbody.AddForceAtPosition(-transform.forward * 10, transform.localPosition);
            _joint.limits = _closedDoorLimits;
            _navMeshObstacle.enabled = true;
        }
    }
}
