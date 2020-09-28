namespace Assets.Common
{
    public interface ITickNotifier
    {
        void RegisterTickListener(IListener listener);
        void RegisterTickListener(IListener listener, float tickInterval);
        void UnregisterTickListener(IListener listener);
    }
}
