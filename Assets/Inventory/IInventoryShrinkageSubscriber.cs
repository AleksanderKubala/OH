namespace Assets.Inventory
{
    public interface IInventoryShrinkageSubscriber
    {
        void OnInventoryShrank(object sender, IInventorySpace removedSpace);
    }
}
