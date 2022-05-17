using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TimestampedEntity.Entities;

public class TimeStampedDbContext : DbContext
{
    protected TimeStampedDbContext(DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeCreationAndUpdatedDateTime();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private void ChangeCreationAndUpdatedDateTime()
    {
        var changedEntriesCopy = this.ChangeTracker.Entries()
            .Where(e => (e.State == EntityState.Added ||
                         e.State == EntityState.Modified)
                        && e.Entity is TimestampedEntity)
            .ToList();
        foreach (var entry in changedEntriesCopy)
        {
            var now = DateTime.Now;
            var createdOnProperty = entry.Properties.FirstOrDefault(_ => _.Metadata.Name.ToLower().Equals("createdon"));
            createdOnProperty.CurrentValue = now;

            var updatedOnProperty = entry.Properties.FirstOrDefault(_ => _.Metadata.Name.ToLower().Equals("updatedon"));
            updatedOnProperty.CurrentValue = now;
        }
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeCreationAndUpdatedDateTime();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
