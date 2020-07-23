using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public class InteractionClose : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;
        [SerializeField]
        private InteractableState _targetState;

        protected override InteractableObject AssociatedInteractable => _openable;

        protected override void Start()
        {
            base.Start();
        }

        public override void Perform(EntityController interactingEntity)
        {
            if (_openable.IsInState(failingStateSet.IncludedStates))//_openable.IsOpen && _openable.HasLock && _openable.KeyLock.IsLocked)
            {
                //successful = false;
            }
            else
            {
                _openable.SetClosed();
                _openable.ChangeState(_targetState);
            }
                //_openable.Close(interactingEntity);
        }
    }
}
