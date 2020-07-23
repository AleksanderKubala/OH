namespace Assets.Data
{
    public interface IActionData
    {
        float ActionRange { get; }
        float ActionSpeed { get; }
        //ActionType Type { get; }
        object ActionType { get; }
    }
}
