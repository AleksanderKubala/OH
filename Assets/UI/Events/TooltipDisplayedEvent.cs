﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.UI.Events
{
    [Serializable]
    public class TooltipDisplayedEvent : UnityEvent<TooltipDisplayedEventArgs>
    {
    }
}
