namespace TaskAPI.Shared;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}