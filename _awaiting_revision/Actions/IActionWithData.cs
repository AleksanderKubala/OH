using OHLogic.Data;
using OHLogic.DataObjects;

namespace Assets.Actions
{
    interface IActionWithData<out TData> : IAction, IObjectWithActionData<TData> where TData : IActionData
    {
    }
}
