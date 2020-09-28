using Assets.UI.Events;

namespace Assets.UI
{
    public interface ITooltipSubscriber
    {
        void OnTooltipDisplayed(TooltipDisplayedEventArgs args);
    }
}
