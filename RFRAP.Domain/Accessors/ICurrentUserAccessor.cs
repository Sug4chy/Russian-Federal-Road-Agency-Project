using RFRAP.Data.Entities;

namespace RFRAP.Domain.Accessors;

public interface ICurrentUserAccessor
{
    Task<User> GetCurrentUser(CancellationToken ct = default);
}