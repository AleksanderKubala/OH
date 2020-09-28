namespace Assets.UI
{
    public interface IContextActionSubscriber
    {
        int ContextMenuPriority { get; }
        string ContextActionTitle { get; }
        bool ShowInContextMenu { get; }

        void OnSelectedInContextMenu();
    }
}
