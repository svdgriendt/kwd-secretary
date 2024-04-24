using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Secretary.Application.Common;

namespace Secretary.Infrastructure.Persistence;

public class SecretaryDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
  public async Task CommitChangesAsync()
  {
    await SaveChangesAsync();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    base.OnModelCreating(modelBuilder);
  }
}