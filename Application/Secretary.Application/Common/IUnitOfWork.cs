namespace Secretary.Application.Common;

public interface IUnitOfWork
{
  Task CommitChangesAsync();
}