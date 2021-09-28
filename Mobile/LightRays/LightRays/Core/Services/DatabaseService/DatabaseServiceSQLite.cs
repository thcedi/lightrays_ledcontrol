using LightRays.Core.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace LightRays.Core.Services
{
    public class DatabaseServiceSQLite : IDatabaseService
    {
        private SQLiteAsyncConnection _connectionAsync;
        private IPlatform _platformService;

        public string dbPath = string.Empty;

        public SQLiteAsyncConnection ConnectionAsync => _connectionAsync ??= new SQLiteAsyncConnection(dbPath, false);

        public DatabaseServiceSQLite(IPlatform platformService)
        {
            _platformService = platformService;

            dbPath = Path.Combine(_platformService.DocumentsDirectory, "lightrays.db3");
            Directory.CreateDirectory(_platformService.DataDirectory);
            PrepareDatabase();
        }

        public bool PrepareDatabase()
        {
            try
            {
                var connection = new SQLiteConnection(dbPath, false);

                // UseFreshDatabase(); // !!! DROP ALL TABLEs !!!
                connection.CreateTable<Preset>();
            }
            catch (System.Exception e)
            {
                var test = e.Message;
                throw;
            }

            return true;
        }

        private async Task UseFreshDatabase()
        {
            await _connectionAsync.DropTableAsync<Preset>();
        }
    }
}