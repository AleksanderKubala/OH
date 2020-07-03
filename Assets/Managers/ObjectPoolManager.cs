using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.UI;
using UnityEngine;

namespace Assets.Managers
{
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField]
        private UITextPool _uiTextPool;
        [SerializeField]
        private Transform _uiTextInstancesParent;
        [SerializeField]
        private ContextMenuActionPool _contextActionPool;
        [SerializeField]
        private Transform _contextActionInstancesParent;

        private void Awake()
        {
            _uiTextPool.Parent = _uiTextInstancesParent;
            _contextActionPool.Parent = _contextActionInstancesParent;
            _uiTextPool.Init();
            _contextActionPool.Init();
        }

        private void Start()
        {

        }
    }
}
