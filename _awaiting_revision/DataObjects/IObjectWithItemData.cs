using OHLogic.Data;

namespace Assets.DataObjects
{
    public interface IObjectWithItemData
    {
        IItemData ItemData { get; }
    }
}
