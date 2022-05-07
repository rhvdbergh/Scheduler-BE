using Microsoft.EntityFrameworkCore;
using Scheduler.Core.Models;

namespace Scheduler.Infra.Sql.Base;

public class SchedulerDbContext : DbContext
{
    public DbSet<Professor> Professors { get; set; }
    public SchedulerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Professor>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(127);
            }
        );
    }
}
