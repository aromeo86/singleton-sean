using SQLite;

namespace TempoPercentStudio.Shared.Database
{
    public class SqliteConnectionFactory
    {
        public ISQLiteAsyncConnection Connect()
        {
            return new SQLiteAsyncConnection(
                Path.Combine(FileSystem.Current.AppDataDirectory, "TempoPercentStudio.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }
    }
}
