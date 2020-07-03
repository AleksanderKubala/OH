using OHLogic.Data;

namespace OHLogic.DataObjects
{
    public interface IObjectWithActionData<out TData> where TData : IActionData
    {
        TData ActionData { get; }
    }
}
