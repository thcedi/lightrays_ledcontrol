using SQLite;

namespace LightRays.Core.Services
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection ConnectionAsync { get; }
    }
}
