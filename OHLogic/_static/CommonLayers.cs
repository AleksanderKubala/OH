using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OnlyHuman
{
    public static partial class CommonValue
    {
        public static class Layers
        {
            public readonly static LayerMask Entity = LayerMask.NameToLayer(LayerNames.Entity);
            public readonly static LayerMask Vision = LayerMask.NameToLayer(LayerNames.Vision);
            public readonly static LayerMask Bodypart = LayerMask.NameToLayer(LayerNames.Bodypart);
            public readonly static LayerMask Hitbox = LayerMask.NameToLayer(LayerNames.Hitbox);
            public readonly static LayerMask Attack = LayerMask.NameToLayer(LayerNames.Attack);
            public readonly static LayerMask Walkable = LayerMask.NameToLayer(LayerNames.Walkable);
            public readonly static LayerMask Structure = LayerMask.NameToLayer(LayerNames.Structure);
        }
    }
}
