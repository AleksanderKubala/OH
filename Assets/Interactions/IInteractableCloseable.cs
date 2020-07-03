using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.OnlyHuman.Characters;

namespace Assets.Interactions
{
    public interface IInteractableCloseable
    {
        void Close(EntityController interactingEntity);
    }
}
