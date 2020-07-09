using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionClose : Interaction
    {
        [SerializeField]
        private InteractableOpenable _openable;

        public override bool Perform(EntityController interactingEntity)
        {
            var possible = base.Perform(interactingEntity);

            _openable.Close(interactingEntity);

            return possible;
        }
    }
}
