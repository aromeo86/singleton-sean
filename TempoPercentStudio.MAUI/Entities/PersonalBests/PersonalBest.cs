namespace TempoPercentStudio.Entities.PersonalBests
{
    public class PersonalBest(int id, double distance, TimeSpan time)
    {
        public int Id { get; } = id;
        public double Distance { get; } = distance;
        public TimeSpan Time { get; } = time;
    }
}
