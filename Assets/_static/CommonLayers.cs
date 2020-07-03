using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.OH
{
    public static partial class CommonValue
    {
        public static class Layers
        {
            public readonly static int Entity = LayerMask.NameToLayer(LayerNames.Entity);
            public readonly static int Vision = LayerMask.NameToLayer(LayerNames.Vision);
            public readonly static int Bodypart = LayerMask.NameToLayer(LayerNames.Bodypart);
            public readonly static int Hitbox = LayerMask.NameToLayer(LayerNames.Hitbox);
            public readonly static int Attack = LayerMask.NameToLayer(LayerNames.Attack);
            public readonly static int Walkable = LayerMask.NameToLayer(LayerNames.Walkable);
            public readonly static int Structure = LayerMask.NameToLayer(LayerNames.Structure);
        }
    }
}
