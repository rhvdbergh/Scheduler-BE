using Microsoft.EntityFrameworkCore;
using Scheduler.Core.Models;

namespace Scheduler.Infra.Sql.Base;

public class SchedulerDbContext : DbContext
{
    public DbSet<Professor> Professors { get; set; }
    public DbSet<LectureGroup> LectureGroups { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<ProfessorPreference> ProfessorPreferences { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    
    
    public SchedulerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Season>(entity =>
        {
            entity.Property(x => x.Name).HasMaxLength(127);
        });
        modelBuilder.Entity<Professor>(entity => { entity.Property(x => x.Name).HasMaxLength(127); }
        );
        modelBuilder.Entity<LectureGroup>(entity =>
            {
                entity.Property(x => x.CourseCode).HasMaxLength(20);
                entity.Property(x => x.CourseName).HasMaxLength(127);
                entity.HasOne(y => y.Professor)
                    .WithMany(y => y.LectureGroups)
                    .HasForeignKey(y => y.ProfessorId);
                entity.HasOne(y => y.Season)
                    .WithMany()
                    .HasForeignKey(y => y.SeasonId);
            }
        );
        modelBuilder.Entity<ProfessorPreference>(entity =>
            {
                entity.HasOne(y => y.Professor)
                    .WithMany(y => y.ProfessorPreferences)
                    .HasForeignKey(y => y.ProfessorId);
            }
        );
        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasOne(x => x.Season)
                .WithMany(x => x.TimeSlots)
                .HasForeignKey(x => x.SeasonId);
            entity.HasOne(x => x.LectureGroup)
                .WithMany(x => x.TimeSlots)
                .HasForeignKey(x => x.LectureGroupId);
        });
    }
}