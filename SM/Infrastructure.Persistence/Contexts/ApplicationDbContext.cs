using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }
        public DbSet<LogError> LogErrors { get; set; }
        public DbSet<LogActivity> LogActivities { get; set; }
        public DbSet<LogHistory> LogHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<MasterUnit> MasterUnits { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        entry.Entity.IsDelete = false;
                        entry.Entity.UnitCode = _authenticatedUser.UnitCode;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure default schema
            builder.HasDefaultSchema("SM");

            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }

            // Setting Auto-increment primary key
            builder.Entity<LogError>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            builder.Entity<LogActivity>()
           .Property(p => p.Id)
           .ValueGeneratedOnAdd();

            builder.Entity<LogHistory>()
           .Property(p => p.Id)
           .ValueGeneratedOnAdd();

            // Setting Auto-default SystemDate CreatedDate
            builder.Entity<LogError>()
            .Property(s => s.Created)
            .HasDefaultValueSql("GETDATE()");

            builder.Entity<LogActivity>()
            .Property(s => s.Created)
            .HasDefaultValueSql("GETDATE()");

            builder.Entity<LogHistory>()
            .Property(s => s.Created)
            .HasDefaultValueSql("GETDATE()");

            // Setting Auto-default SystemDate CreatedDate
            builder.Entity<Image>()
            .Property(s => s.Created)
            .HasDefaultValueSql("GETDATE()");

            // Setting Unitcode none
            builder.Entity<LogError>()
            .Property(e => e.ProcessContent)
            .IsUnicode(false);

            builder.Entity<LogActivity>()
            .Property(e => e.ProcessContent)
            .IsUnicode(false);

            builder.Entity<LogHistory>()
            .Property(e => e.Functional)
            .IsUnicode(false);

            builder.Entity<Master>()
            .Property(e => e.Key)
            .IsUnicode(false);

            // Ignore column UnitCode in table Master
            builder.Entity<Master>()
            .Ignore(a => a.UnitCode);

            builder.Entity<MasterUnit>()
            .HasKey(a => new { a.MasterId, a.UnitCode });

            base.OnModelCreating(builder);
        }
    }
}
