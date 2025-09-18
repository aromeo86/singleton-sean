namespace TempoPercentStudio.Entities.PersonalBests
{
    public class NewPersonalBest(double distance, TimeSpan time)
    {
        public double Distance { get; } = distance;
        public TimeSpan Time { get; } = time;
    }
}
