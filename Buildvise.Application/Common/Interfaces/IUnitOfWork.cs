namespace Buildvise.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}