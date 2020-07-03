using System;
using Assets.Common;
using UnityEngine;

namespace Assets.UI
{
    [CreateAssetMenu(fileName = "ContextActionPool", menuName = "Object Pools/Context Action Pool")]
    public class ContextMenuActionPool : UnityObjectPool<ContextMenuAction>
    {
        public static ContextMenuActionPool Instance { get; private set; }

        public override void Init()
        {
            if(Instance != null) { throw new Exception("ContextMenuActionPool already exists"); }
            base.Init();
            Instance = this;
        }

        protected override void Reset(ContextMenuAction usedObject)
        {
            usedObject.Subscription = null;
            usedObject.gameObject.SetActive(false);
        }
    }
}
