using Assets.UI;
using Assets.Managers;

namespace Assets.Interactions
{
    public class ContextInteractionSubscription : ContextActionSubscription
    {
        private readonly InteractionPerformedCallback _interactionCall;

        public ContextInteractionSubscription(InteractionPerformedCallback interactionSelected, string actionTitle)
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
