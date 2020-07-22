using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public class InteractionClose : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;

        protected override void Start()
        {
            base.Start();
        }

        public override void Perform(EntityController interactingEntity)
        {
            if (_openable.IsOpen && _openable.HasLock && _openable.KeyLock.IsLocked)
            {
                //successful = false;
            }
            else
            {
                _openable.SetClosed();
            }
                //_openable.Close(interactingEntity);
            SetEffectiveByInteractableState();
        }

        protected override void SetEffectiveByInteractableState()
        {
            if (!_openable.IsOpen && IsEffective)
            {
                IsEffective = false;
            }
            else
            {
                IsEffective = true;
            }
        }
    }
}
