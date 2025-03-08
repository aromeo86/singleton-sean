using SQLite;
using TempoPercentStudio.Shared.Database;

namespace TempoPercentStudio.Entities.PersonalBests
{
    public class PersonalBestRepository(SqliteConnectionFactory sqliteConnectionFactory)
    {
        public async Task<IEnumerable<PersonalBest>> GetAll()
        {
            ISQLiteAsyncConnection connection = sqliteConnectionFactory.Connect();
            List<PersonalBestDto> personalBestDtos =  await connection.Table<PersonalBestDto>().ToListAsync();

            return personalBestDtos.Select(pb => new PersonalBest(
                pb.Id,
                pb.Distance,
                TimeSpan.FromMilliseconds(pb.TimeMilliseconds)));
        }

        public async Task<PersonalBest> Create(NewPersonalBest newPersonalBest)
        {
            ISQLiteAsyncConnection connection = sqliteConnectionFactory.Connect();
            PersonalBestDto personalBestDto = new()
            {
                Distance = newPersonalBest.Distance,
                TimeMilliseconds = newPersonalBest.Time.TotalMilliseconds
            };

            await connection.InsertAsync(personalBestDto);

            return new PersonalBest(
                personalBestDto.Id, 
                personalBestDto.Distance,
                TimeSpan.FromMilliseconds(personalBestDto.TimeMilliseconds));
        }

        public async Task Delete(int id)
        {
            ISQLiteAsyncConnection connection = sqliteConnectionFactory.Connect();
            await connection.Table<PersonalBestDto>().DeleteAsync(pb => pb.Id == id);
        }
    }
}
