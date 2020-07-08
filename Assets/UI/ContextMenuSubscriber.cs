using UnityEngine;

namespace Assets.UI
{
    [RequireComponent(typeof(ContextMenuHandler))]
    public class ContextMenuSubscriber : MonoBehaviour
    {
        [SerializeField]
        protected ContextMenuHandler _contextMenuHandler;
    }
}
