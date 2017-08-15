using System;

namespace EFCoreGlobalQueryFilters.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
