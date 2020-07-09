using System;
using Assets.Common;
using UnityEngine;

namespace Assets.UI
{
    [CreateAssetMenu(fileName = "ContextActionPool", menuName = "Object Pools/Context Action Pool")]
    public class ContextActionPool : UnityObjectPool<UIContextAction>
    {
        public static ContextActionPool Instance { get; private set; }

        public override void Init()
        {
            if(Instance != null) { throw new Exception("ContextMenuActionPool already exists"); }
            base.Init();
            Instance = this;
        }

        protected override void Reset(UIContextAction usedObject)
        {
            usedObject.Subscription = null;
            usedObject.gameObject.SetActive(false);
        }
    }
}
