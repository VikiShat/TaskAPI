using TaskAPI.App.ErrorLogs.Repositories.IRepositories;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.ErrorLogs.Repositories;

public class ErrorLogRepository :  BaseRepository<ErrorLog>, IErrorLogRepository
{
    public ErrorLogRepository(ApplicationDbContext db) : base(db)
    {
    }
}