using Assets.Data;

namespace Assets.DataObjects
{
    public interface IObjectWithVisionData
    {
        IVisionData VisionData { get; }
    }
}
