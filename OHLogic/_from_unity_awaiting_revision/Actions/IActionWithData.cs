using OHLogic.Data;
using OHLogic.DataObjects;

namespace OHLogic.Actions
{
    interface IActionWithData<out TData> : IAction, IObjectWithActionData<TData> where TData : IActionData
    {
    }
}
