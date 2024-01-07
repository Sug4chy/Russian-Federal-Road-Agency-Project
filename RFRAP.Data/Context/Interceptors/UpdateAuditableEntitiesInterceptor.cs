using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Context.Interceptors;

public class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        foreach (var entry in dbContext.ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    entry.Property(ae => ae.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(ae => ae.DeletedAt).CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Property(ae => ae.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entry.Property(ae => ae.CreatedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(ae => ae.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    break;
                default:
                    continue;
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}