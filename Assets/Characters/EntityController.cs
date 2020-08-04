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
        public IInteraction CurrentInteraction
        {
            get
            {
                return _performedInteraction;
            }
            protected set
            {
                if(value != null)
                {

                }
                else
                {

                }
                _performedInteraction = value;
            }
        }

        private void Awake()
        {
            _interactionQueue = new LinkedList<IInteraction>();
            var inventory = new Inventory(this);
            Inventory = inventory;
            inventory.Expand(GetInventorySpaces());
        }

        private void Start()
        {
        }

        private void Update()
        {
            if(CurrentInteraction == null && _interactionQueue.Any())
            {
                CurrentInteraction = _interactionQueue.First.Value;
                _interactionQueue.Remove(CurrentInteraction);

                Transform destination = CurrentInteraction.GetInteractionSource();
                if(destination != null)
                {
                    _interactionTrigger.enabled = true;
                    SetDestinationFlag(destination);
                }
                else
                {
                    PerformCurrentInteraction();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(CurrentInteraction != null && ReferenceEquals(other.transform, CurrentInteraction.GetInteractionSource()))
            {
                PerformCurrentInteraction();
                _interactionTrigger.enabled = false;
            }
        }

        public void Walk(Vector3 pointWorldPosition)
        {
            CurrentInteraction = null;
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

        public IEnumerable<IInventorySpace> GetInventorySpaces()
        {
            return new List<IInventorySpace> {
                new InventorySpace(gameObject.name + "'s personal space" , float.MaxValue),
                new InventorySpace("Zig", float.MaxValue)
                };
        }

        private void PerformCurrentInteraction()
        {
            CurrentInteraction.Perform(this);
            CurrentInteraction = null;
        }
    }
}

