using System.Collections;
using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionAttempt : IInteractionAttempt
    {
        private readonly List<InteractionAttemptArgument> _attemptArguments;

        public InteractionAttempt(IInteraction attemptedInteraction) : this(attemptedInteraction, new List<InteractionAttemptArgument>()) { }

        public InteractionAttempt(IInteraction attemptedInteration, List<InteractionAttemptArgument> arguments)
        {
            AttemptedInteaction = attemptedInteration;
            _attemptArguments = arguments;
        }

        public EntityController InteractingEntity { get; set; }
        protected IInteraction AttemptedInteaction { get; }

        public Transform GetTarget()
        {
            return AttemptedInteaction.GetInteractionSource();
        }

        public IEnumerator<InteractionAttemptArgument> GetEnumerator()
        {
            return _attemptArguments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Perform()
        {
            AttemptedInteaction.Attempt(InteractingEntity, _attemptArguments);
        }
    }
}
