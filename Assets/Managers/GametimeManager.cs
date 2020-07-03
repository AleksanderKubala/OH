namespace Assets.Managers
{
    public class GametimeManager
    {
        public static readonly float GametimeSpeedFactor = 4.0f;

        public static float GametimeSecond => 1.0f / GametimeSpeedFactor;
        public static float GametimeMinute => GametimeSecond * 60.0f;
        public static float GametimeHour => GametimeMinute * 60.0f;
    }
}
