namespace Assets.Data
{

    public interface IVisionData
    {
        float MaximumLeftAngle { get; }
        float MaximumRightAngle {get; }
        float MaximumTopAngle { get; }
        float MaximumBottomAngle { get; }
        float Radius { get; }
        float MinimumLuminousIntensity { get; }
        float OptimalLuminousIntensity { get; }
    }
}