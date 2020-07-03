using System.Runtime.CompilerServices;
using Assets.Managers;
using Assets.UI;

namespace Assets.Interactions
{
    public class ContextInteractionSubscription : ContextActionSubscription
    {
        private readonly InteractionCall _interactionCall;

        public ContextInteractionSubscription(InteractionCall interactionSelected, string actionTitle)
        {
            _interactionCall = interactionSelected;
            ActionTitle = actionTitle;
            OnContextActionSelected = OnInteractionSelected;
        }

        private void OnInteractionSelected()
        {
            _interactionCall?.Invoke(GameManager.Player);
        }
    }
}
