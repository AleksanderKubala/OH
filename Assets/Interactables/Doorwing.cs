﻿using Assets.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Interactables
{
    public class Doorwing : Openable
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

        public override void SetOpen()
        {
            var limits = _joint.limits;
            limits.max = _maxOpenDoorAngle;
            _joint.limits = limits;

            _navMeshObstacle.enabled = false;
            _rigidbody.AddForceAtPosition(transform.forward * 10, transform.localPosition);
        }

        public override void SetClosed()
        {
            var limits = _joint.limits;
            limits.max = _maxClosedDoorAngle;
            _joint.limits = limits;

            _rigidbody.AddForceAtPosition(-transform.forward * 10, transform.localPosition);
            _navMeshObstacle.enabled = true;
        }
    }
}
