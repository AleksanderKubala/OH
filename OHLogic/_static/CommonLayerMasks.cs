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
        public static class LayerMasks
        {
            public readonly static LayerMask Entity = LayerMask.GetMask(LayerNames.Entity);
            public readonly static LayerMask Vision = LayerMask.GetMask(LayerNames.Vision);
            public readonly static LayerMask Bodypart = LayerMask.GetMask(LayerNames.Bodypart);
            public readonly static LayerMask Hitbox = LayerMask.GetMask(LayerNames.Hitbox);
            public readonly static LayerMask Attack = LayerMask.GetMask(LayerNames.Attack);
            public readonly static LayerMask Walkable = LayerMask.GetMask(LayerNames.Walkable);
            public readonly static LayerMask Structure = LayerMask.GetMask(LayerNames.Structure);
            public readonly static LayerMask VisionLayersOfInterest = Entity | Attack;
        }
    }
}
