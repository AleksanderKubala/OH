using UnityEngine.Events;

namespace Assets.UI
{
    public class ContextActionSubscription
    {
        public int Priority { get; set; }
        public string ActionTitle { get; set; }
        public UnityAction OnContextActionSelected { get; set; }
    }
}
