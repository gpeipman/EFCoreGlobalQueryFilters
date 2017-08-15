using System;

namespace EFCoreGlobalQueryFilters.Services
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
