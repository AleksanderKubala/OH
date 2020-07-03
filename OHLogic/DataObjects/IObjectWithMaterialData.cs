using OHLogic.Data;

namespace OHLogic.DataObjects
{
    public interface IObjectWithMaterialData
    {
        IMaterialData MaterialData { get; }
    }
}
