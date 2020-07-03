using OHLogic.Body;

namespace OHLogic.Data
{
    public interface IBodypartData
    {
        BodypartType BodypartType { get; }
        float MaximumHealth { get; }

        Bodypart CreateBodypartInstance();
    }

}