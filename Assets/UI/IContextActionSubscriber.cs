using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.UI
{
    public interface IContextActionSubscriber
    {
        int ContextMenuPriority { get; }
        string ContextActionTitle { get; }
        bool ShowInContextMenu { get; }

        void OnSelectedByContextMenu();
    }
}
