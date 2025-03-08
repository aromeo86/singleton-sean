using SQLite;

namespace TempoPercentStudio.Entities.PersonalBests
{
    public class PersonalBestDto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 

        public double Distance { get; set; }
        public double TimeMilliseconds { get; set; }
    }
}
