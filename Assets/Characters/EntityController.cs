using UnityEngine;
using Assets.OH.Movement;
using System.Collections.Generic;
using Assets.Movement;
using System;
using Assets.Interactions;
using System.Linq;
using Assets.Inventory;
using Assets.GameEntity;
using Assets.Items;
using Assets.Body;

namespace Asset.OnlyHuman.Characters
{
    public class EntityController : MonoBehaviour, IGameEntity, IInventorySpaceProvider
    {
        [SerializeField]
        protected EntityMovementController _movementController;
        [SerializeField]
        protected DestinationFlag _destinationFlag;
        [SerializeField]
        protected SphereCollider _interactionTrigger;
        protected IInteraction _performedInteraction;
        protected LinkedList<IInteraction> _interactionQueue;

        public IGameEntityStatistics Statistics {get; private set; }
        public IGameEntityBody Body { get; private set; }
        public IInventory Inventory { get; private set; }
        public IInteraction PerformedInteraction
        {
            get
            {
                return _performedInteraction;
            }
            protected set
            {
                if(value != null)
                {
                    _interactionTrigger.enabled = true;
                }
                else
                {
                    _interactionTrigger.enabled = false;
                }
                _performedInteraction = value;
            }
        }

        private void Awake()
        {
            _interactionQueue = new LinkedList<IInteraction>();
            var inventory = new Inventory(this);
            inventory.Expand(this);
            Inventory = inventory;
        }

        private void Start()
        {
        }

        private void Update()
        {
            if(PerformedInteraction == null && _interactionQueue.Any())
            {
                PerformedInteraction = _interactionQueue.First.Value;
                _interactionQueue.Remove(PerformedInteraction);
                SetDestinationFlag(PerformedInteraction.InteractionSource);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(ReferenceEquals(other.transform, PerformedInteraction?.InteractionSource))
            {
                PerformedInteraction.Perform(this);
                PerformedInteraction = null;
            }
        }

        public void Walk(Vector3 pointWorldPosition)
        {
            PerformedInteraction = null;
            SetDestinationFlag(pointWorldPosition);
        }

        public void SetDestinationFlag(Vector3 worldSpaceDestination)
        {
            SetDestinationFlag(null, worldSpaceDestination, EntityMovementController.StandardDistance);
        }

        public void SetDestinationFlag(Vector3 worldSpaceDestination, float allowedDistanceFromDestination)
        {
            SetDestinationFlag(null, worldSpaceDestination, allowedDistanceFromDestination);
        }

        public void SetDestinationFlag(Transform parent)
        {
            SetDestinationFlag(parent, Vector3.zero, EntityMovementController.StandardDistance);
        }

        public void SetDestinationFlag(Transform parent, float allowedDistanceFromDestination)
        {
            SetDestinationFlag(parent, Vector3.zero, allowedDistanceFromDestination);
        }

        public void SetDestinationFlag(Transform parent, Vector3 relativePosition, float allowedDistanceFromDestination)
        {
            _destinationFlag.Set(parent, relativePosition);
            _movementController.StoppingDistance = allowedDistanceFromDestination;
        }

        public void ClearDestinationFlag()
        {
            SetDestinationFlag(null, transform.position, EntityMovementController.StandardDistance);
        }

        public void AddInteractionToPerform(IInteraction interactionToPerform)
        {
            _interactionQueue.AddLast(interactionToPerform);
        }

        public void CancelInteraction(IInteraction interaction)
        {
            _interactionQueue.Remove(interaction);
        }

        public bool Equip(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Unequip(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool PutToInventory(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Drop(IItem item)
        {
            throw new NotImplementedException();
        }

        public IInventorySpace GetInventorySpace()
        {
            return new InventorySpace(float.MaxValue);
        }
    }
}

