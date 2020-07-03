using System;
using System.IO;
using Assets.Common;
using UnityEngine;

namespace Assets.UI
{
    [CreateAssetMenu(fileName = "UiTextPool", menuName = "Object Pools/UI Text Pool ")]
    public class UITextPool : UnityObjectPool<UIText>
    {
        public static UITextPool Instance { get; private set; }

        public override void Init()
        {
            if (Instance != null) { throw new Exception("UITextPool already exists"); }
            base.Init();
            Instance = this;
        }

        protected override void Reset(UIText usedObject)
        {
            usedObject.gameObject.SetActive(false);
            usedObject.Text = "";
            usedObject.transform.position = Vector3.zero;
        }
    }
}
