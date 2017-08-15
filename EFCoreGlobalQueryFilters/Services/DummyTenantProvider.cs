using System;

namespace EFCoreGlobalQueryFilters.Services
{
    public class DummyTenantProvider : ITenantProvider
    {
        public Guid GetTenantId()
        {
            return Guid.Parse("069b57ab-6ec7-479c-b6d4-a61ba3001c86");
        }
    }
}
