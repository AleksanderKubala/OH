using Assets.Body;

namespace Assets.Data
{
    public interface IBodypartData
    {
        BodypartType BodypartType { get; }
        float MaximumHealth { get; }

        Bodypart CreateBodypartInstance();
    }

}