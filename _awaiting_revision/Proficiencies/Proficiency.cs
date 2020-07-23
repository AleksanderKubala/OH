namespace Assets.Proficiencies
{
    public class Proficiency
    {
        protected float GainedExperience { get; set; }

        public float Ratio(Proficiency other)
        {
            float ratio = GainedExperience / other.GainedExperience;

            return ratio;
        }
    }
}
