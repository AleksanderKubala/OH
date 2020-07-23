using OHLogic.Data;

namespace Assets.DataObjects
{
    public interface IObjectWithActionData<out TData> where TData : IActionData
    {
        TData ActionData { get; }
    }
}
