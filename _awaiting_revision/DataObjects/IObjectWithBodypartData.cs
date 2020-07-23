using OHLogic.Data;

namespace Assets.DataObjects
{
    public interface IObjectWithBodypartData
    {
        IBodypartData BodypartData { get; }
    }
}
