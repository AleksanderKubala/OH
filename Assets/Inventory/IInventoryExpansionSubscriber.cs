namespace Assets.Inventory
{
    public interface IInventoryExpansionSubscriber
    {
        void OnInventoryExpanded(object sender, IInventorySpace newInventorySpace);
    }
}
