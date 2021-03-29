using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SM.Entity.IHasTimes;
using SM.Entity.Model.System;
using System;

namespace SM.Entity
{
    public class SMContext : DbContext
    {
        public SMContext(DbContextOptions<SMContext> options) : base(options)
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
            ChangeTracker.Tracked += UpdateTimestamps;
        }

        public virtual DbSet<LogError> LogErrors { get; set; }
        public virtual DbSet<LogActivity> LogActivities { get; set; }
        public virtual DbSet<LogHistory> LogHistories { get; set; }
        public virtual DbSet<MasterCatalog> MasterCatalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure default schema
            modelBuilder.HasDefaultSchema("SM");

            // Setting Auto-increment primary key
            modelBuilder.Entity<LogError>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<LogActivity>()
           .Property(p => p.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<LogHistory>()
           .Property(p => p.Id)
           .ValueGeneratedOnAdd();

            // Setting Auto-default SystemDate CreatedDate
            modelBuilder.Entity<LogError>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<LogActivity>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<LogHistory>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            // Setting Unitcode none
            modelBuilder.Entity<LogError>()
            .Property(e => e.ProcessContent)
            .IsUnicode(false);

            modelBuilder.Entity<LogActivity>()
            .Property(e => e.ProcessContent)
            .IsUnicode(false);

            modelBuilder.Entity<LogHistory>()
            .Property(e => e.UserName)
            .IsUnicode(false);

            modelBuilder.Entity<LogHistory>()
            .Property(e => e.Functional)
            .IsUnicode(false);

            // Configuration table MasterCatalog
            modelBuilder.Entity<MasterCatalog>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<MasterCatalog>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MasterCatalog>()
            .Property(s => s.LastUpdatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

            modelBuilder.Entity<MasterCatalog>()
           .Property(e => e.Key)
           .IsUnicode(false);

            modelBuilder.Entity<MasterCatalog>()
           .Property(e => e.TypeCatalog)
           .IsUnicode(false);
        }

        #region UpdateTimestamps
        private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                        entityWithTimestamps.Deleted = DateTime.UtcNow;
                        e.Entry.Context.Set<LogHistory>().Add(
                        new LogHistory
                        {
                            LogContent = $"Stamped for delete: {e.Entry.Entity}",
                            Functional = "Deleted",
                            IP = "127.0.0.1",
                            UserName = "Administrator"
                        });
                        //e.Entry.State = EntityState.Added;
                        break;
                    case EntityState.Modified:
                        entityWithTimestamps.Modified = DateTime.UtcNow;
                        e.Entry.Context.Set<LogHistory>().Add(
                        new LogHistory
                        {
                            LogContent = $"Stamped for update: {e.Entry.Entity}",
                            Functional = "Updated",
                            IP = "127.0.0.1",
                            UserName = "Administrator"
                        });
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.Added = DateTime.UtcNow;
                        e.Entry.Context.Set<LogHistory>().Add(
                        new LogHistory
                        {
                            LogContent = $"Stamped for insert: {e.Entry.Entity}",
                            Functional = "Added",
                            IP = "127.0.0.1",
                            UserName = "Administrator"
                        });
                        break;
                }
            }
        }
        #endregion
    }
}
