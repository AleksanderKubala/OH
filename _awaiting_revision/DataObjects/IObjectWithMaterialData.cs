using OHLogic.Data;

namespace Assets.DataObjects
{
    public interface IObjectWithMaterialData
    {
        IMaterialData MaterialData { get; }
    }
}
