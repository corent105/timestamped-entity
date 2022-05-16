using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TimestampedEntity.Entites;

public class TimeStampedDbContext : DbContext
{
    private static void SetCreatedOnDateTime(object entity)
    {
        if (entity is TimestampedEntity timestampedEntity)
        {
            var now = DateTime.Now;
            timestampedEntity.CreatedOn = now;
            timestampedEntity.UpdatedOn = now;
        }
    }
    
    private static void SetUpdatedOnDateTime(object entity)
    {
        if (entity is TimestampedEntity timestampedEntity)
        {
            timestampedEntity.UpdatedOn = DateTime.Now;
        }
    }

    public override EntityEntry Add(object entity)
    {
        SetCreatedOnDateTime(entity);
        return base.Add(entity);
    }

    public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
    {
        SetCreatedOnDateTime(entity);
        return base.Add(entity);
    }

    public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = new CancellationToken())
    {
        SetCreatedOnDateTime(entity);
        return base.AddAsync(entity, cancellationToken);
    }

    public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = new CancellationToken())
    {
        SetCreatedOnDateTime(entity);
        return base.AddAsync(entity, cancellationToken);
    }

    public override void AddRange(params object[] entities)
    {
        foreach (var entity in entities)
        {
            SetCreatedOnDateTime(entity);
        }
        base.AddRange(entities);
    }

    public override void AddRange(IEnumerable<object> entities)
    {
        foreach (var entity in entities)
        {
            SetCreatedOnDateTime(entity);
        }
        base.AddRange(entities);
    }

    public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entity in entities)
        {
            SetCreatedOnDateTime(entity);
        }
        return base.AddRangeAsync(entities, cancellationToken);
    }

    public override Task AddRangeAsync(params object[] entities)
    {
        foreach (var entity in entities)
        {
            SetCreatedOnDateTime(entity);
        }
        return base.AddRangeAsync(entities);
    }

    

    public override EntityEntry Update(object entity)
    {
        SetUpdatedOnDateTime(entity);
        return base.Update(entity);
    }


    public override void UpdateRange(params object[] entities)
    {
        foreach (var entity in entities)
        {
            SetUpdatedOnDateTime(entity);
        }
        base.UpdateRange(entities);
    }

    public override void UpdateRange(IEnumerable<object> entities)
    {
        foreach (var entity in entities)
        {
            SetUpdatedOnDateTime(entity);
        }
        base.UpdateRange(entities);
    }

    public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
    {
        SetUpdatedOnDateTime(entity);
        return base.Update(entity);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
}