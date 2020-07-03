using OHLogic.Data;

namespace OHLogic.DataObjects
{
    public interface IObjectWithVisionData
    {
        IVisionData VisionData { get; }
    }
}
