using UnityEngine;
using Assets.OH.Movement;
using System.Collections.Generic;
using Assets.Movement;
using System;
using System.Linq;
using Assets.Inventory;
using Assets.GameEntity;
using Assets.Items;
using Assets.Body;
using Assets.Common;

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
        protected IGameAction _performedAction;
        protected LinkedList<IGameAction> _actionQueue;

        public IGameEntityStatistics Statistics {get; private set; }
        public IGameEntityBody Body { get; private set; }
        public IInventory Inventory { get; private set; }
        public IGameAction CurrentAction
        {
            get
            {
                return _performedAction;
            }
            protected set
            {
                if(value != null)
                {

                }
                else
                {

                }
                _performedAction = value;
            }
        }

        private void Awake()
        {
            _actionQueue = new LinkedList<IGameAction>();
            var inventory = new Inventory(this);
            Inventory = inventory;
            inventory.Expand(GetInventorySpaces());
        }

        private void Start()
        {
        }

        private void Update()
        {
            if(CurrentAction == null && _actionQueue.Any())
            {
                CurrentAction = _actionQueue.First.Value;
                _actionQueue.Remove(CurrentAction);

                Transform destination = CurrentAction.GetTarget();
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
            if(CurrentAction != null && ReferenceEquals(other.transform, CurrentAction.GetTarget()))
            {
                PerformCurrentInteraction();
                _interactionTrigger.enabled = false;
            }
        }

        public void Walk(Vector3 pointWorldPosition)
        {
            CurrentAction = null;
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

        public void AddActionToPerform(IGameAction interactionToPerform)
        {
            _actionQueue.AddLast(interactionToPerform);
        }

        public void CancelAction(IGameAction interaction)
        {
            _actionQueue.Remove(interaction);
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
            CurrentAction.Perform();
            CurrentAction = null;
        }
    }
}

